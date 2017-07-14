
namespace Domain
{
    public enum OperationCode
    {
        Ok = 0,
        AuthenticationInvalidCredentials = 1,
        AuthenticationUserIsNotActive = 4,
        AuthenticationUserMustChangePassword = 8,
        ClientVersionMismatch = 12,
        EntityDeleteFailed = 16,
        EntitySaveFailed = 20,
        EntitySaveWithWarnings = 24,
        EntityWasNotFound = 28,
        EntityWithExternalReferencesCanNotBeDeleted = 32,
        Success = 40,
        UnhandledError = 44,

        

        //custom errors >= 500
    }
}
