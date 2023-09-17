namespace TransportGlobalWeb.UI.Models.ConfigurationModels.TransporterContextConfigurationModels
{
    public class TransporterContextEndpointsConfigurationModel
    {
        public CompanyEndpointsConfigurationModel? CompanyEndpoints { get; set; }

        public VehicleEndpointsConfigurationModel? VehicleEndpoints { get; set; }

        public EmployeeEndpointsConfigurationModel? EmployeeEndpoints { get; set; }
    }
}
