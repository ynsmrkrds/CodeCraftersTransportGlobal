using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateVehicle;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportContract
{
    public class CreateTransportContractCommandHandler : IRequestHandler<CreateTransportContractCommandRequest, CreateTransportContractCommandResponse>
    {
        private readonly ITransportContractRepository _transportContractRepository;
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateTransportContractCommandHandler(ITransportContractRepository transportContractRepository, ITransportRequestRepository transportRequestRepository, IUserRepository userRepository, IMapper mapper)
        {
            _transportContractRepository = transportContractRepository;
            _transportRequestRepository = transportRequestRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<CreateTransportContractCommandResponse> Handle(CreateTransportContractCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            if (_transportContractRepository.IsThereAgreedContract(request.TransportRequestID)) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.CannotMakeContractAgreement));

            if (_userRepository.HasCompany(userID) == false) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.UserHasNotCompany));

            int customerID = _transportRequestRepository.GetByID(request.TransportRequestID)?.UserID ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportRequest);

            TransportContractEntity transportEntity = _mapper.Map<TransportContractEntity>(request);
            transportEntity.UserID = customerID;
            transportEntity.CompanyID = userEntity.ActiveCompany!.ID;

            _transportContractRepository.Add(transportEntity);

            int effectedRows = _transportContractRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
