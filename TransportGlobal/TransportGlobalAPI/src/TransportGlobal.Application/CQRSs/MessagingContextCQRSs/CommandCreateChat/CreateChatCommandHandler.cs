using AutoMapper;
using MediatR;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateChat
{
    public class CreateChatCommandHandler : IRequestHandler<CreateChatCommandRequest, CreateChatCommandResponse>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public CreateChatCommandHandler(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public Task<CreateChatCommandResponse> Handle(CreateChatCommandRequest request, CancellationToken cancellationToken)
        {
            ChatEntity chatEntity = _mapper.Map<ChatEntity>(request);
            _chatRepository.Add(chatEntity);

            int effectedRows = _chatRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateChatCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateChatCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
