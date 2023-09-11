namespace TransportGlobal.Domain.Constants
{
    public static class ExceptionConstants
    {
        public const string ServerSideException = "An error has occurred with the server!";
        public const string TokenError = "Please login, then try again!";
        public const string NoAuthority = "You are not authorized to access here!";
        public const string NotFoundUser = "No such user is registered in the system!";
        public const string NotFoundCompany = "No such company is registered in the system!";
        public const string NotFoundVehicle = "No such vehicle is registered in the system!";
        public const string NotFoundEmployee = "No such employee is registered in the system!";
        public const string CannotUpdateWithValue = "You cannot update with this value!";
        public const string NotFoundTransportRequest = "No such transport request is registered in the system!";
        public const string NotFoundTransportContract = "No such transport contract is registered in the system!";
    }
}
