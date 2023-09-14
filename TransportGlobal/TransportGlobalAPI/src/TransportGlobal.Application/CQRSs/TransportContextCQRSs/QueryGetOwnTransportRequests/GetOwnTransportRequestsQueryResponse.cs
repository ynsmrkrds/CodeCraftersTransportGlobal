using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportRequests
{
    public class GetOwnTransportRequestsQueryResponse : BaseQueryListResponseDTO<TransportRequestViewModel>
    {
        public GetOwnTransportRequestsQueryResponse(IEnumerable<TransportRequestViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
