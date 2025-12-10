namespace DiagonAlley2._0.Services
{
    public static class UserValidationHelper
    {
        public static string? ValidateCredentials(string username, string password)
        {
            bool usernameEmpty = string.IsNullOrWhiteSpace(username);
            bool passwordEmpty = string.IsNullOrWhiteSpace(password);

            if (usernameEmpty && passwordEmpty)
                return "Username and password cannot be empty.";

            if (usernameEmpty)
                return "Username cannot be empty.";

            if (passwordEmpty)
                return "Password cannot be empty.";

            return null;
        }
    }
}
