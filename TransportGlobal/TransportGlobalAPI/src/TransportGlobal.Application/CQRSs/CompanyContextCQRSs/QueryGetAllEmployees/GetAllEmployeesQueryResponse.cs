using TransportGlobal.Application.ViewModels.CompanyContextViewModels;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllEmployees
{
    public class GetAllEmployeesQueryResponse
    {
        public ICollection<EmployeeViewModel> Employees { get; set; }

        public GetAllEmployeesQueryResponse(ICollection<EmployeeViewModel> employees)
        {
            Employees = employees;
        }
    }
}
