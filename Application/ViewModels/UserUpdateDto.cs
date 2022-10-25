using System;
using static Domain.Constants.Constants;

namespace Application.ViewModels
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public DateTime InsertionDate { get; set; }
        public StatusCodes Status { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public UserTypes UserType { get; set; }
    }
}
