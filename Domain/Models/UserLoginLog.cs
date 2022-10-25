using Domain.Common;
using static Domain.Constants.Constants;

namespace Domain.Models
{
    public class UserLoginLog : ExtendedBaseModel
    {
        public int UserId { get; set; }
        public LoginStatus LoginStatus { get; set; }
        public virtual User User { get; set; }
    }
}
