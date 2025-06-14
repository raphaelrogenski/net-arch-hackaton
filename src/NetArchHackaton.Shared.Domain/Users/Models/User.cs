namespace NetArchHackaton.Shared.Domain.Users
{
    public class User : EntityBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
