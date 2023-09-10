using AutoMapper;
using MediatR;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommandRequest, CreateMessageCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public Task<CreateMessageCommandResponse> Handle(CreateMessageCommandRequest request, CancellationToken cancellationToken)
        {
            MessageEntity messageEntity = _mapper.Map<MessageEntity>(request);
            _messageRepository.Add(messageEntity);

            int effectedRows = _messageRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateMessageCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateMessageCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
