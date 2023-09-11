using MediatR;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetCompany
{
    public class GetCompanyQueryRequest : IRequest<GetCompanyQueryResponse>
    {
        public int ID { get; set; }

        public GetCompanyQueryRequest(int id)
        {
            ID = id;
        }
    }
}
