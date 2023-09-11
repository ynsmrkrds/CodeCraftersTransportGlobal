using MediatR;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContracts;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContractsByUserType
{
    public class GetOwnTransportContractsQueryRequest : IRequest<GetOwnTransportContractsQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public GetOwnTransportContractsQueryRequest(PaginationModel pagination)
        {
            Pagination = pagination;
        }
    }
}
