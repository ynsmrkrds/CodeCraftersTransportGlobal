using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportRequest
{
    public class CreateTransportRequestCommandHandler : IRequestHandler<CreateTransportRequestCommandRequest, CreateTransportRequestCommandResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public CreateTransportRequestCommandHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public Task<CreateTransportRequestCommandResponse> Handle(CreateTransportRequestCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            TransportRequestEntity transportRequestEntity = _mapper.Map<TransportRequestEntity>(request);
            transportRequestEntity.UserID = tokenModel.UserID;

            _transportRequestRepository.Add(transportRequestEntity);

            int effectedRows = _transportRequestRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateTransportRequestCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateTransportRequestCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
