﻿using TransportGlobalWeb.UI.Models.ConfigurationModels.MessagingContextConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.TransporterContextConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.UserContextConfigurationModels;

namespace TransportGlobalWeb.UI.Models.ConfigurationModels
{
    public class ApiEndpointsConfigurationModel
    {
        public string? BaseUrl { get; set; }

        public int? PageSize { get; set; }

        public UserContextEndpointsConfigurationModel? UserContextEndpoints { get; set; }

        public TransporterContextEndpointsConfigurationModel? TransporterContextEndpoints { get; set; }

        public MessagingContextEndpointsConfigurationModel? MessagingContextEndpoints { get; set; }
    }
}
