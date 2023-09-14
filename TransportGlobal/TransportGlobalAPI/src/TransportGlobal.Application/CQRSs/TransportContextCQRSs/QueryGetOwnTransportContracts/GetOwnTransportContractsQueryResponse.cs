using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.TransportContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContracts
{
    public class GetOwnTransportContractsQueryResponse : BaseQueryListResponseDTO<TransportContractViewModel>
    {
        public GetOwnTransportContractsQueryResponse(IEnumerable<TransportContractViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
