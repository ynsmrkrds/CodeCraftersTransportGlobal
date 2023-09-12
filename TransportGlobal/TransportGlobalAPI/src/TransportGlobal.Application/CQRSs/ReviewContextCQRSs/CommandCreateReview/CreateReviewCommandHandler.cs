using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.ReviewContextRepositories;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ITransportContractRepository _transportContractRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, ITransportContractRepository transportContractRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _transportContractRepository = transportContractRepository;
            _mapper = mapper;
        }

        public Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

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
