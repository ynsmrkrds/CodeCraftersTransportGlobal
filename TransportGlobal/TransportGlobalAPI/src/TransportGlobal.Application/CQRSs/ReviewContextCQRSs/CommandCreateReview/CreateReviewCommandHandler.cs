using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.ReviewContextRepositories;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ITransportContractRepository _transportContractRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, ITransportContractRepository transportContractRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _transportContractRepository = transportContractRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            TransportContractEntity? transportContractEntity = _transportContractRepository.GetByID(request.TransportContractID) ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportContract);
            if (_companyRepository.IsCompanyActive(transportContractEntity.CompanyID) == false) return Task.FromResult(new CreateReviewCommandResponse(ResponseConstants.CannotReview));
            _transportContractRepository.DetachEntity(transportContractEntity);

            if (_transportContractRepository.IsOwner(request.TransportContractID, userID) == false) return Task.FromResult(new CreateReviewCommandResponse(ResponseConstants.NotTransportContractOwner));

            if (_transportContractRepository.CanReview(request.TransportContractID) == false) return Task.FromResult(new CreateReviewCommandResponse(ResponseConstants.CannotReview));

            ReviewEntity reviewEntity = _mapper.Map<CreateReviewCommandRequest, ReviewEntity>(request);
            _reviewRepository.Add(reviewEntity);

            int effectedRows = _reviewRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateReviewCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateReviewCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
