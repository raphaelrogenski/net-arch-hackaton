using System.Net.Mail;

namespace NetArchHackaton.Shared.Application.Auth.Validators
{
    internal static class EmailValidator
    {
        internal static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
