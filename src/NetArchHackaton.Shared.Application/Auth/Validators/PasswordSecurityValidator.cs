using System.Text.RegularExpressions;

namespace NetArchHackaton.Shared.Application.Auth.Validators
{
    internal static class PasswordSecurityValidator
    {
        internal static bool IsValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_\-+=\[\]{};':""\\|,.<>\/?]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
