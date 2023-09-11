using TransportGlobal.Application.ViewModels.TransporterContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicleEmployees
{
    public class GetVehicleEmployeesQueryResponse
    {
        public List<EmployeeViewModel> Employees { get; set; }

        public GetVehicleEmployeesQueryResponse(List<EmployeeViewModel> employees)
        {
            Employees = employees;
        }
    }
}
