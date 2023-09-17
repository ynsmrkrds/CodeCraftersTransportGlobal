using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateEmployee;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.MessagingContextEnums;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportContract
{
    public class CreateTransportContractCommandHandler : IRequestHandler<CreateTransportContractCommandRequest, CreateTransportContractCommandResponse>
    {
        private readonly ITransportContractRepository _transportContractRepository;
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public CreateTransportContractCommandHandler(ITransportContractRepository transportContractRepository, ITransportRequestRepository transportRequestRepository, IUserRepository userRepository, IChatRepository chatRepository, IMessageRepository messageRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _transportContractRepository = transportContractRepository;
            _transportRequestRepository = transportRequestRepository;
            _userRepository = userRepository;
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public Task<CreateTransportContractCommandResponse> Handle(CreateTransportContractCommandRequest request, CancellationToken cancellationToken)
        {
            if (_vehicleRepository.CanVehicleWork(request.VehicleID) == false) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.VehicleCanNotWork));

            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            TransportRequestEntity transportRequestEntity = _transportRequestRepository.GetByID(request.TransportRequestID) ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportRequest);
            if (transportRequestEntity.IsDeleted) throw new ClientSideException(ExceptionConstants.NotFoundTransportRequest);
            _transportRequestRepository.DetachEntity(transportRequestEntity);

            VehicleEntity vehicleEntity = _vehicleRepository.GetByID(request.VehicleID) ?? throw new ClientSideException(ExceptionConstants.NotFoundVehicle);
            if (vehicleEntity.IsDeleted) throw new ClientSideException(ExceptionConstants.NotFoundVehicle);
            
            _vehicleRepository.DetachEntity(vehicleEntity);

            if (_transportContractRepository.IsThereAgreedContract(request.TransportRequestID)) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.CannotMakeContractAgreement));

            if (_userRepository.HasCompany(userID) == false) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.UserHasNotCompany));

            if (_vehicleRepository.IsOwner((int)request.VehicleID, userID) == false) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.NotVehicleOwner));

            int customerID = _transportRequestRepository.GetByID(request.TransportRequestID)?.UserID ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportRequest);

            TransportContractEntity transportContractEntity = _mapper.Map<TransportContractEntity>(request);
            transportContractEntity.UserID = customerID;
            transportContractEntity.CompanyID = userEntity.ActiveCompany!.ID;

            transportContractEntity = _transportContractRepository.Add(transportContractEntity);

            int effectedRows = _transportContractRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.CreateFailed));

            bool isSuccessful = SendMessage(userID, customerID, request.TransportRequestID, transportContractEntity.ID);
            if (isSuccessful == false) return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateTransportContractCommandResponse(ResponseConstants.SuccessfullyCreated));
        }

        private bool SendMessage(int senderUserID, int receiverUserID, int transportRequestID, int transportContractID)
        {
            string message;
            ChatEntity chatEntity;

            if (_chatRepository.IsExists(transportRequestID, senderUserID, receiverUserID))
            {
                chatEntity = _chatRepository.GetByTransportRequestID(transportRequestID, senderUserID) ?? throw new ClientSideException(ExceptionConstants.NotFoundChat);
                message = "Our new offer to you is this:";
            }
            else
            {
                chatEntity = new(transportRequestID, senderUserID, receiverUserID);

                chatEntity = _chatRepository.Add(chatEntity);

                int effectedRows = _chatRepository.SaveChanges();
                if (effectedRows == 0) return false;

                message = "Hello. Here's what we're offering you:";
            }

            _messageRepository.Add(new MessageEntity(chatEntity.ID, senderUserID, receiverUserID, MessageContentType.Text, message, DateTime.Now));
            _messageRepository.Add(new MessageEntity(chatEntity.ID, senderUserID, receiverUserID, MessageContentType.Contract, transportContractID.ToString(), DateTime.Now));

            int createMessageEffectedRows = _messageRepository.SaveChanges();
            return createMessageEffectedRows != 0;
        }
    }
}
