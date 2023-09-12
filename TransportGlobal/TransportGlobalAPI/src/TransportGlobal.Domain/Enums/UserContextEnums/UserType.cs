namespace TransportGlobal.Domain.Enums.UserContextEnums
{
    public enum UserType
    {
        Shipper,
        Customer
    }

    public static class UserTypeExtensions
    {
        public static string Value(this UserType userType)
        {
            return userType switch
            {
                UserType.Shipper => "Shipper",
                UserType.Customer => "Customer",
                _ => throw new Exception("Unknown value!"),
            };
        }
    }
}
