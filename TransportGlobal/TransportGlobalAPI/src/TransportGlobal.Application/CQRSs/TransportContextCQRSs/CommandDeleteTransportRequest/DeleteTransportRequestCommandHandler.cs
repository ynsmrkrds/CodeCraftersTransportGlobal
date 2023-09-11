using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandDeleteTransportRequest
{
    public class DeleteTransportRequestCommandHandler : IRequestHandler<DeleteTransportRequestCommandRequest, DeleteTransportRequestCommandResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;

        public DeleteTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository)
        {
            _transportRequestRepository = transportRequestRepository;
        }

        public Task<DeleteTransportRequestCommandResponse> Handle(DeleteTransportRequestCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            TransportRequestEntity transportRequestEntity = _transportRequestRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportRequest);

            if (tokenModel.UserID != transportRequestEntity.UserID) return Task.FromResult(new DeleteTransportRequestCommandResponse(ResponseConstants.NotTransportRequestOwner));

            if (_transportRequestRepository.CanDelete(request.ID) == false) return Task.FromResult(new DeleteTransportRequestCommandResponse(ResponseConstants.DeleteFailed));

            _transportRequestRepository.Delete(transportRequestEntity);

            int effectedRows = _transportRequestRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteTransportRequestCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteTransportRequestCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
