using TransportGlobal.Application.ViewModels.CompanyContextViewModels;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllCompanies
{
    public class GetAllCompaniesQueryResponse
    {
        public ICollection<CompanyViewModel> Companies { get; set; }

        public GetAllCompaniesQueryResponse(ICollection<CompanyViewModel> companies)
        {
            Companies = companies;
        }
    }
}
