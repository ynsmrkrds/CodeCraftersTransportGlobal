using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportContract
{
    public class GetTransportContractQueryHandler : IRequestHandler<GetTransportContractQueryRequest, GetTransportContractQueryResponse>
    {
        private readonly ITransportContractRepository _transportContractRepository;
        private readonly IMapper _mapper;

        public GetTransportContractQueryHandler(ITransportContractRepository transportContractRepository, IMapper mapper)
        {
            _transportContractRepository = transportContractRepository;
            _mapper = mapper;
        }

        public Task<GetTransportContractQueryResponse> Handle(GetTransportContractQueryRequest request, CancellationToken cancellationToken)
        {
            TransportContractEntity transportContract = _transportContractRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundTransportContract);

            TransportContractViewModel transportContractViewModel = _mapper.Map<TransportContractViewModel>(transportContract);

            return Task.FromResult(new GetTransportContractQueryResponse(transportContractViewModel));
        }
    }
}
