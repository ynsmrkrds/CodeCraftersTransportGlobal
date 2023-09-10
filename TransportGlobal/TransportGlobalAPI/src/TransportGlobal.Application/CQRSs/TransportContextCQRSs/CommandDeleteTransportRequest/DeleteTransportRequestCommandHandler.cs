using MediatR;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;
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
            if (tokenModel == null) return Task.FromResult(new DeleteTransportRequestCommandResponse(ResponseConstants.DeleteFailed));

            TransportRequestEntity? transportRequestEntity = _transportRequestRepository.GetByID(request.ID);
            if(transportRequestEntity == null) throw new ClientSideException(ExceptionConstants.NotFoundTransportRequest);

            if (transportRequestEntity.StatusType != StatusType.Pending && transportRequestEntity.StatusType != StatusType.Cancelled) return Task.FromResult(new DeleteTransportRequestCommandResponse(ResponseConstants.DeleteFailed));

            _transportRequestRepository.Delete(transportRequestEntity);

            int effectedRows = _transportRequestRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteTransportRequestCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteTransportRequestCommandResponse(ResponseConstants.SuccessfullyDeleted));

        }
    }
}
