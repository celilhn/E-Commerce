using Domain.Common;
using static Domain.Constants.Constants;

namespace Domain.Models
{
    public class User : ExtendedBaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public UserTypes UserType { get; set; }
    }
}
