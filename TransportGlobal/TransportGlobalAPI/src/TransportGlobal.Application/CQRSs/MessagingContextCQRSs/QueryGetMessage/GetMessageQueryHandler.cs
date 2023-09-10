using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.MessagingContextViewModels;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessage
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessageQueryRequest, GetMessageQueryResponse>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public Task<GetMessageQueryResponse> Handle(GetMessageQueryRequest request, CancellationToken cancellationToken)
        {
            List<MessageEntity> messages = _messageRepository.GetAll().ToList();

            List<MessageViewModel> messagesViewModels = _mapper.Map<List<MessageViewModel>>(messages);

            return Task.FromResult(new GetMessageQueryResponse(messagesViewModels));
        }
    }
}
