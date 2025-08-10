namespace IdentityService.Domain.DTO
{
    public class LoginUserDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
