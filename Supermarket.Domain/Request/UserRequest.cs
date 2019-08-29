namespace Supermarket.Domain.Request
{
    public class UserRequest
    {
        public string RealName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        
        public string UserRight { get; set; }
    }
}