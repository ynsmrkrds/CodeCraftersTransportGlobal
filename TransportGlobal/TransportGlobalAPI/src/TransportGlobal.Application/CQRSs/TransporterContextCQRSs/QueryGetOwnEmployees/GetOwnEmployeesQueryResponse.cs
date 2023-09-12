using TransportGlobal.Application.ViewModels.TransporterContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnEmployees
{
    public class GetOwnEmployeesQueryResponse
    {
        public ICollection<EmployeeViewModel> Employees { get; set; }

        public GetOwnEmployeesQueryResponse(ICollection<EmployeeViewModel> employees)
        {
            Employees = employees;
        }
    }
}
