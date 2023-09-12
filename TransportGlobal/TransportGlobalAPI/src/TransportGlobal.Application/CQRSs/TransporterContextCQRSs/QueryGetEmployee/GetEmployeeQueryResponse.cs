using TransportGlobal.Application.ViewModels.TransporterContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetEmployee
{
    public class GetEmployeeQueryResponse
    {
        public EmployeeViewModel Employee { get; set; }

        public GetEmployeeQueryResponse(EmployeeViewModel employee)
        {
            Employee = employee;
        }
    }
}
