using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
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

            TransportRequestEntity transportRequestEntity = _transportRequestRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportRequest);

            if (tokenModel.UserID != transportRequestEntity.UserID) return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.NotTransportRequestOwner));

            if (_transportRequestRepository.CanUpdate(request.ID) == false) return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.UpdateFailed));

            _mapper.Map(request, transportRequestEntity);
            _transportRequestRepository.Update(transportRequestEntity);

            int effectedRows = _transportRequestRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateTransportRequestCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
