using TransportGlobal.Application.ViewModels.TransporterContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnCompany
{
    public class GetOwnCompanyQueryResponse
    {
        public CompanyViewModel Company { get; set; }

        public GetOwnCompanyQueryResponse(CompanyViewModel company)
        {
            Company = company;
        }
    }
}
