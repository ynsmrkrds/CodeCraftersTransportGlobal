using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandAgreeTransportContract
{
    public class AgreeTransportContractCommandHandler : IRequestHandler<AgreeTransportContractCommandRequest, AgreeTransportContractCommandResponse>
    {
        private readonly ITransportContractRepository _transportContractRepository;
        private readonly IMapper _mapper;

        public AgreeTransportContractCommandHandler(ITransportContractRepository transportContractRepository, IMapper mapper)
        {
            _transportContractRepository = transportContractRepository;
            _mapper = mapper;
        }

        public Task<AgreeTransportContractCommandResponse> Handle(AgreeTransportContractCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            TransportContractEntity transportContractEntity = _transportContractRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportContract);

            if (transportContractEntity.UserID != userID) return Task.FromResult(new AgreeTransportContractCommandResponse(ResponseConstants.NotTransportContractOwner));

            if (_transportContractRepository.IsThereAgreedContract(transportContractEntity.TransportRequestID)) return Task.FromResult(new AgreeTransportContractCommandResponse(ResponseConstants.CannotMakeContractAgreement));

            transportContractEntity.IsAgreed = true;
            _transportContractRepository.Update(transportContractEntity);

            int effectedRows = _transportContractRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new AgreeTransportContractCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new AgreeTransportContractCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
