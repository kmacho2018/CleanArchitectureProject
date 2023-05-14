namespace Web.API.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Jwt : User
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

    }
}
