using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.MessagingContextViewModels;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetChat
{
    public class GetChatQueryHandler : IRequestHandler<GetChatQueryRequest, GetChatQueryResponse>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public GetChatQueryHandler(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public Task<GetChatQueryResponse> Handle(GetChatQueryRequest request, CancellationToken cancellationToken)
        {
            List<ChatEntity> chats = _chatRepository.GetAll().ToList();

            List<ChatViewModel> chatViewModels = _mapper.Map<List<ChatViewModel>>(chats);

            return Task.FromResult(new GetChatQueryResponse(chatViewModels));
        }
    }
}
