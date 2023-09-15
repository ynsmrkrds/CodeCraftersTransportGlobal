namespace TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Vehicle
{
    public class GetOwnVehiclesResponseModel : BaseListResponseModel<VehicleResponseModel>
    {
        public GetOwnVehiclesResponseModel(ICollection<VehicleResponseModel> list, int totalCount) : base(list, totalCount)
        {
        }
    }
}
