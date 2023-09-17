using TransportGlobal.Domain.Models;

namespace TransportGlobal.Domain.Constants
{
    public static class ResponseConstants
    {
        public static readonly ResponseConstantModel SuccessfullyCreated = new(true, "Successfully created!");

        public static readonly ResponseConstantModel CreateFailed = new(false, "Create failed! Please try again.");

        public static readonly ResponseConstantModel SuccessfullyDeleted = new(true, "Successfully deleted!");

        public static readonly ResponseConstantModel DeleteFailed = new(false, "Delete failed! Please try again.");

        public static readonly ResponseConstantModel SuccessfullyUpdated = new(true, "Successfully updated!");

        public static readonly ResponseConstantModel UpdateFailed = new(false, "Update failed! Please try again.");

        public static readonly ResponseConstantModel LoginSuccessful = new(true, "Login successful!");

        public static readonly ResponseConstantModel EmailOrPasswordIncorrect = new(false, "Email or password is incorrect!");

        public static readonly ResponseConstantModel CurrentPasswordIncorrect = new(false, "The Current password is incorrect!");

        public static readonly ResponseConstantModel ExistsUserWithSameEmail = new(false, "A user with the same email address already exists!");

        public static readonly ResponseConstantModel ExistsCompanyWithSameEmail = new(false, "A company with the same email address already exists!");

        public static readonly ResponseConstantModel UserHasCompany = new(false, "The user already has a company!");

        public static readonly ResponseConstantModel UserHasNotCompany = new(false, "The user has not a company!");

        public static readonly ResponseConstantModel NotCompanyOwner = new(false, "The user is not a company admin!");

        public static readonly ResponseConstantModel ExistsVehicleWithSameIdentificationNumber = new(false, "A vehicle with the same identification number already exists!");

        public static readonly ResponseConstantModel NotVehicleOwner = new(false, "The vehicle does not belong to the company of the user!");

        public static readonly ResponseConstantModel ExistsEmployeeWithSameEmail = new(false, "An employee with the same email address already exists!");

        public static readonly ResponseConstantModel NotEmployeeOwner = new(false, "The employee does not belong to the company of the user!");

        public static readonly ResponseConstantModel VehicleCanNotWork = new(false, "The vehicle cannot operate due to insufficient number of teams!");

        public static readonly ResponseConstantModel VehicleStatusCannotUpdate = new(false, "The status of vehicle cannot be updated because the vehicle is currently running!");

        public static readonly ResponseConstantModel EmployeeCannotAssignToVehicle = new(false, "An employee cannot be assigned to a vehicle at work!");

        public static readonly ResponseConstantModel NotTransportRequestOwner = new(false, "The transport request does not belong to the user!");

        public static readonly ResponseConstantModel CannotMakeContractAgreement = new(false, "Since a contract has been made for this transport request, no further contract can be made!");

        public static readonly ResponseConstantModel NotTransportContractOwner = new(false, "The transport request does not belong to the user!");

        public static readonly ResponseConstantModel CannotCreateChatForYourself = new(false, "You cannot create a chat for yourself!");

        public static readonly ResponseConstantModel CannotCreateChatForSameUser = new(false, "New chat cannot be created for the same user!");

        public static readonly ResponseConstantModel CannotReview = new(false, "You can not review!");

        public static readonly ResponseConstantModel CannotCompleteTransportRequest = new(false, "You can not complete this transport request!");

        public static readonly ResponseConstantModel TransportDateEarlier = new(false, "Transport date cannot be before today!");
    }
}
