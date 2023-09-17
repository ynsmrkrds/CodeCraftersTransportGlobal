using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Application.ViewModels.MessagingContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetOwnChats
{
    public class GetOwnChatsQueryHandler : IRequestHandler<GetOwnChatsQueryRequest, GetOwnChatsQueryResponse>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public GetOwnChatsQueryHandler(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public Task<GetOwnChatsQueryResponse> Handle(GetOwnChatsQueryRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            IEnumerable<ChatEntity> chats = _chatRepository.GetChatsByUserType(tokenModel.UserType, tokenModel.UserID);

            IEnumerable<ChatViewModel> chatViewModels = _mapper.Map<IEnumerable<ChatViewModel>>(chats);

            return Task.FromResult(new GetOwnChatsQueryResponse(chatViewModels, request.Pagination));
        }
    }
}
