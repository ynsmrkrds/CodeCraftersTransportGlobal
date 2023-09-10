using TransportGlobal.Application.ViewModels.CompanyContextViewModels;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetEmployee
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
