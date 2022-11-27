using static Domain.Constants.Constants;

namespace Application.ViewModels
{
    public class AdminUserAddDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string ImageUrl { get; set; }
        public AdminUserTypes AdminUserType { get; set; }
    }
}
