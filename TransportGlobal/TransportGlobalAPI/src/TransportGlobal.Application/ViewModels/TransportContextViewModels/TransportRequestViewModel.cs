﻿using TransportGlobal.Domain.Enums.TransportContextEnums;

namespace TransportGlobal.Application.ViewModels.TransportContextViewModels
{
    public class TransportRequestViewModel : BaseViewModel
    {
        public int UserID { get; set; }

        public TransportType TransportType { get; set; }

        public double Weight { get; set; }

        public double Volume { get; set; }

        public DateTime TransportDate { get; set; }

        public DateTime RequestDate { get; set; }

        public string LoadingAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public StatusType StatusType { get; set; }

        public TransportRequestViewModel(int id, DateTime createdDate, int userID, TransportType transportType, double weight, double volume, DateTime transportDate, DateTime requestDate, string loadingAddress, string deliveryAddress, StatusType statusType) : base(id, createdDate)
        {
            UserID = userID;
            TransportType = transportType;
            Weight = weight;
            Volume = volume;
            TransportDate = transportDate;
            RequestDate = requestDate;
            LoadingAddress = loadingAddress;
            DeliveryAddress = deliveryAddress;
            StatusType = statusType;
            
        }
    }
}