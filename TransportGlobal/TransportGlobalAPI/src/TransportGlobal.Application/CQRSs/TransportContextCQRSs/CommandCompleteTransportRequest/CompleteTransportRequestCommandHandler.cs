using MediatR;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandAgreeTransportContract;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCompleteTransportRequest
{
    public class CompleteTransportRequestCommandHandler : IRequestHandler<CompleteTransportRequestCommandRequest, CompleteTransportRequestCommandResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;

        public CompleteTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository)
        {
            _transportRequestRepository = transportRequestRepository;
        }

        public Task<CompleteTransportRequestCommandResponse> Handle(CompleteTransportRequestCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            TransportRequestEntity transportRequestEntity = _transportRequestRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportRequest);

            if (userID != transportRequestEntity.UserID) return Task.FromResult(new CompleteTransportRequestCommandResponse(ResponseConstants.NotTransportRequestOwner));

            if(transportRequestEntity.StatusType == TransportRequestStatusType.Pending) return Task.FromResult(new CompleteTransportRequestCommandResponse(ResponseConstants.CannotCompleteTransportRequest));
        
            transportRequestEntity.StatusType = TransportRequestStatusType.Done;
            _transportRequestRepository.Update(transportRequestEntity);

            int effectedRows = _transportRequestRepository.SaveChanges();
            if(effectedRows == 0) return Task.FromResult(new CompleteTransportRequestCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new CompleteTransportRequestCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
