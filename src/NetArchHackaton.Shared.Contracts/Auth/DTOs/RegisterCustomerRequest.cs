namespace NetArchHackaton.Shared.Contracts.Auth.DTOs
{
    public class RegisterCustomerRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
    }
}
