namespace TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Employee
{
    public class GetOwnEmployeesResponseModel : BaseListResponseModel<GetEmployeeResponseModel>
    {
        public GetOwnEmployeesResponseModel(ICollection<GetEmployeeResponseModel> list, int totalCount) : base(list, totalCount)
        {
        }
    }
}
