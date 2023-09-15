namespace TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Employee
{
    public class GetVehicleEmployeesResponseModel : BaseListResponseModel<GetEmployeeResponseModel>
    {
        public GetVehicleEmployeesResponseModel(ICollection<GetEmployeeResponseModel> list, int totalCount) : base(list, totalCount)
        {
        }
    }
}
