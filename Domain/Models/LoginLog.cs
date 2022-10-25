using Domain.Common;
using static Domain.Constants.Constants;

namespace Domain.Models
{
    public class LoginLog : ExtendedBaseModel
    {
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public LoginStatus LoginStatus { get; set; }
        public LoginTypes LoginType { get; set; }
    }
}
