using TransportGlobal.Application.ViewModels.CompanyContextViewModels;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetCompany
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
