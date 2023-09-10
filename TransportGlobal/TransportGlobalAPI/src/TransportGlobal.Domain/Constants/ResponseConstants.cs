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

        public static readonly ResponseConstantModel NotCompanyOwner = new(false, "The user to be deleted is not the company user!");

        public static readonly ResponseConstantModel ExistsVehicleWithSameIdentificationNumber = new(false, "A vehicle with the same identification number already exists!");

        public static readonly ResponseConstantModel NotVehicleOwner = new(false, "The vehicle to be deleted does not belong to the company of the user!");

        public static readonly ResponseConstantModel ExistsEmployeeWithSameEmail = new(false, "An employee with the same email address already exists!");

        public static readonly ResponseConstantModel NotEmployeeOwner = new(false, "The employee to be deleted does not belong to the company of the user!");
    }
}
