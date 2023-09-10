using AutoMapper;
using MediatR;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.MessagingContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.MessagingContextRepositories;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandDeleteChat
{
    public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommandRequest, DeleteChatCommandResponse>
    {
        private readonly IChatRepository _chatRepository;

        public DeleteChatCommandHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public Task<DeleteChatCommandResponse> Handle(DeleteChatCommandRequest request, CancellationToken cancellationToken)
        {
            ChatEntity? chatEntity = _chatRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundChat);
            _chatRepository.Delete(chatEntity);

            int effectedRows = _chatRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteChatCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteChatCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
