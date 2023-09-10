using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Models;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransport
{
    public class CreateTransportCommandHandler : IRequestHandler<CreateTransportCommandRequest, CreateTransportCommandResponse>
    {
        private readonly ITransportRepository _transportRepository;
        private readonly IMapper _mapper;

        public CreateTransportCommandHandler(ITransportRepository transportRepository, IMapper mapper)
        {
            _transportRepository = transportRepository;
            _mapper = mapper;
        }

        public Task<CreateTransportCommandResponse> Handle(CreateTransportCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            if (tokenModel == null) return Task.FromResult(new CreateTransportCommandResponse(ResponseConstants.CreateFailed));

            TransportEntity transportEntity = _mapper.Map<TransportEntity>(request);

            _transportRepository.Add(transportEntity);

            int effectedRows = _transportRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateTransportCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateTransportCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
