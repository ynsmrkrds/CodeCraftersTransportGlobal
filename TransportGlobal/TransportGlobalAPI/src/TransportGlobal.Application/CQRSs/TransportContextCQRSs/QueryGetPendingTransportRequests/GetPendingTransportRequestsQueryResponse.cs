using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequests
{
    public class GetPendingTransportRequestsQueryResponse : BaseQueryListResponseDTO<TransportRequestViewModel>
    {
        public GetPendingTransportRequestsQueryResponse(IEnumerable<TransportRequestViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
