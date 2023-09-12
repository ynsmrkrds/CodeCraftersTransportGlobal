using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.MessagingContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessagesByChatID
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessagesByChatIDQueryRequest, GetMessagesByChatIDQueryResponse>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public GetMessageQueryHandler(IMessageRepository messageRepository, IChatRepository chatRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public Task<GetMessagesByChatIDQueryResponse> Handle(GetMessagesByChatIDQueryRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            if (_chatRepository.IsChatBelongToUser(request.ChatID, tokenModel.UserType, tokenModel.UserID) == false) throw new ClientSideException(ExceptionConstants.ChatDoesntBelongToUser);

            List<MessageEntity> messages = _messageRepository.GetMessagesByChatID(request.ChatID).WithPagination(request.Pagination).ToList();

            List<MessageViewModel> messagesViewModels = _mapper.Map<List<MessageViewModel>>(messages);

            return Task.FromResult(new GetMessagesByChatIDQueryResponse(messagesViewModels));
        }
    }
}
