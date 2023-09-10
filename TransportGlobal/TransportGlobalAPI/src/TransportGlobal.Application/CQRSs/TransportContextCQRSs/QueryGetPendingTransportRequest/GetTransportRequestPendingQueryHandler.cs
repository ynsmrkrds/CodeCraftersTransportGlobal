using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequest
{
    public class GetTransportRequestPendingQueryHandler : IRequestHandler<GetTransportRequestPendingQueryRequest, GetTransportRequestPendingQueryResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetTransportRequestPendingQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public Task<GetTransportRequestPendingQueryResponse> Handle(GetTransportRequestPendingQueryRequest request, CancellationToken cancellationToken)
        {
            List<TransportRequestEntity> transportRequestEntities = _transportRequestRepository.GetTransportRequestWithPendingEntities();
            List<TransportRequestViewModel> transportRequestViewModels = _mapper.Map<List<TransportRequestViewModel>>(transportRequestEntities);

            return Task.FromResult(new GetTransportRequestPendingQueryResponse(transportRequestViewModels));
        }
    }
}
