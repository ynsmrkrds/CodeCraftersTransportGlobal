using AutoMapper;
using MediatR;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.ObjectExtensions;
using TransportGlobal.Domain.Repositories.TransportContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequests
{
    public class GetPendingTransportRequestsQueryHandler : IRequestHandler<GetPendingTransportRequestsQueryRequest, GetPendingTransportRequestsQueryResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetPendingTransportRequestsQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public Task<GetPendingTransportRequestsQueryResponse> Handle(GetPendingTransportRequestsQueryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<TransportRequestEntity> transportRequestEntities = _transportRequestRepository.GetPendingTransportRequests();

            IEnumerable<TransportRequestViewModel> transportRequestViewModels = _mapper.Map<IEnumerable<TransportRequestViewModel>>(transportRequestEntities);

            return Task.FromResult(new GetPendingTransportRequestsQueryResponse(transportRequestViewModels, request.Pagination));
        }
    }
}
