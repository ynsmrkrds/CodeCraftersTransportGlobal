using TransportGlobal.Application.ViewModels.TransporterContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetCompany
{
    public class GetCompanyQueryResponse
    {
        public CompanyViewModel Company { get; set; }

        public GetCompanyQueryResponse(CompanyViewModel company)
        {
            Company = company;
        }
    }
}
