namespace MyKoloApi.DTOs
{
    public class LoggedInUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string JwtToken { get; set; }
    }
}