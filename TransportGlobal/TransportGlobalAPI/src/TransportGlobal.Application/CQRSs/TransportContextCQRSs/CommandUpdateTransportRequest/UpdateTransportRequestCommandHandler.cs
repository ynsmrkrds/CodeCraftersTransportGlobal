using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportRequest;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest
{
    public class UpdateTransportRequestCommandHandler : IRequestHandler<UpdateTransportRequestCommandRequest, UpdateTransportRequestCommandResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public UpdateTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public Task<UpdateTransportRequestCommandResponse> Handle(UpdateTransportRequestCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);
            if (tokenModel == null) return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.UpdateFailed));

            TransportRequestEntity? transportRequestEntity = _transportRequestRepository.GetByID(request.ID);
            if (transportRequestEntity == null) return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.UpdateFailed));

            if(transportRequestEntity.StatusType != StatusType.Pending && transportRequestEntity.StatusType != StatusType.Cancelled) return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.UpdateFailed));

            _mapper.Map(request, transportRequestEntity);
            _transportRequestRepository.Update(transportRequestEntity);

            int effectedRows = _transportRequestRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
