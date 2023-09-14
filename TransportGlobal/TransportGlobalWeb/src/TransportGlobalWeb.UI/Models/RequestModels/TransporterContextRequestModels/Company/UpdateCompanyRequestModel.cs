﻿namespace TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Company
{
    public class UpdateCompanyRequestModel
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
