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
            List<TransportRequestEntity> transportRequestEntities = _transportRequestRepository.GetPendingTransportRequests().WithPagination(request.Pagination).ToList();

            List<TransportRequestViewModel> transportRequestViewModels = _mapper.Map<List<TransportRequestViewModel>>(transportRequestEntities);

            return Task.FromResult(new GetPendingTransportRequestsQueryResponse(transportRequestViewModels));
        }
    }
}
