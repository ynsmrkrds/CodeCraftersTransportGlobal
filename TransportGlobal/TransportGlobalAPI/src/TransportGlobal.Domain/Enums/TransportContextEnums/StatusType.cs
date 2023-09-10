namespace TransportGlobal.Domain.Enums.TransportContextEnums
{
    public enum StatusType
    {
        Pending,
        DealDone,
        Cancelled,
        InProcess,
        Done
    }

    public static class StatusTypeExtension
    {
        public static string Value(this StatusType statusType)
        {
            return statusType switch
            {
                StatusType.Pending => "The request has been created but no agreement has been made yet.",
                StatusType.DealDone => "The deal is done.",
                StatusType.Cancelled => "Request canceled.",
                StatusType.InProcess => "The transportation process is ongoing and not yet complete.",
                StatusType.Done => "Transportation successfully completed.",
                _ => throw new Exception("Unknown value!"),
            };
        }
    }
}
