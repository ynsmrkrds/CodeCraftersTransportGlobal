using MediatR;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetEmployee
{
    public class GetEmployeeQueryRequest : IRequest<GetEmployeeQueryResponse>
    {
        public int ID { get; set; }

        public GetEmployeeQueryRequest(int id)
        {
            ID = id;
        }
    }
}
