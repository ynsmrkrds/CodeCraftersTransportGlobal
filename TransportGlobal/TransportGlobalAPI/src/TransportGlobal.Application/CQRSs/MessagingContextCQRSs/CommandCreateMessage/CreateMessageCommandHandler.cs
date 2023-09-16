using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommandRequest, CreateMessageCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(IMessageRepository messageRepository, IChatRepository chatRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public Task<CreateMessageCommandResponse> Handle(CreateMessageCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            if (_chatRepository.IsChatBelongToUser(request.ChatID, tokenModel.UserType, tokenModel.UserID) == false) throw new ClientSideException(ExceptionConstants.ChatDoesntBelongToUser);

            ChatEntity chatEntity = _chatRepository.GetByID(request.ChatID) ?? throw new ClientSideException(ExceptionConstants.NotFoundChat);

            MessageEntity messageEntity = _mapper.Map<MessageEntity>(request);
            messageEntity.SenderUserID = tokenModel.UserID;
            messageEntity.ReceiverUserID = chatEntity.ReceiverUserID;

            _messageRepository.Add(messageEntity);

            int effectedRows = _messageRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateMessageCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateMessageCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
