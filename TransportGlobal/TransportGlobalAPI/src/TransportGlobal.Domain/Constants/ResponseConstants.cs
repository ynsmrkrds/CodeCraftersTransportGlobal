using TransportGlobal.Domain.Models;

namespace EventManagement.Domain.Constants
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
    }
}
