namespace TransportGlobal.Domain.Enums.TransportContextEnums
{

    public enum TransportType
    {
        HomeToHomeTransportation,
        OfficeTransportation,
        LargeVolumeAndWeightOfTransport,
        AntiqueFurniture,
        WhiteGoodsTransport,
        ArtworkTransportation
    }
    public static class TransportTypeExtensions
    {
        public static string Value(this TransportType transportType)
        {
            return transportType switch
            {
                TransportType.HomeToHomeTransportation => "Home to home transportation",
                TransportType.OfficeTransportation => "Office transportation",
                TransportType.LargeVolumeAndWeightOfTransport => "Large volume and weight of transport",
                TransportType.AntiqueFurniture => "Antique furniture",
                TransportType.WhiteGoodsTransport => "White goods transport",
                TransportType.ArtworkTransportation => "Artwork transportation",
                _ => throw new Exception("Unknown value!"),
            };

        }
    }
}
