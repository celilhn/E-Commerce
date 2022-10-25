using Domain.Common;
using static Domain.Constants.Constants;

namespace Domain.Models
{
    public class UserLoginLog : ExtendedBaseModel
    {
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public LoginStatus LoginStatus { get; set; }
    }
}
