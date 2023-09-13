using TransportGlobal.Domain.Models;

namespace TransportGlobal.Domain.Constants
{
    public static class ExceptionConstants
    {
        public static readonly ExceptionConstantModel ServerSideException = new("An error has occurred with the server!");

        public static readonly ExceptionConstantModel TokenError = new("Please login, then try again!");

        public static readonly ExceptionConstantModel NoAuthority = new("You are not authorized to access here!");

        public static readonly ExceptionConstantModel NotFoundUser = new("No such user is registered in the system!");

        public static readonly ExceptionConstantModel NotFoundCompany = new("No such company is registered in the system!");

        public static readonly ExceptionConstantModel NotFoundVehicle = new("No such vehicle is registered in the system!");

        public static readonly ExceptionConstantModel NotFoundEmployee = new("No such employee is registered in the system!");

        public static readonly ExceptionConstantModel CannotUpdateWithValue = new("You cannot update with this value!");

        public static readonly ExceptionConstantModel NotFoundTransportRequest = new("No such transport request is registered in the system!");

        public static readonly ExceptionConstantModel NotFoundTransportContract = new("No such transport contract is registered in the system!");

        public static readonly ExceptionConstantModel NotFoundChat = new("There is no such chat in the system!");

        public static readonly ExceptionConstantModel ChatDoesntBelongToUser = new("Chat does not belong to the user!");

        public static readonly ExceptionConstantModel MessageContentInvalid = new("Message content type and content do not match!");

        public static readonly ExceptionConstantModel NotFoundReview = new("No such review is registered in the system!");

        public static readonly ExceptionConstantModel ReviewScoreOutOfRange = new("The review score should be between 1 and 5!");
    }
}
