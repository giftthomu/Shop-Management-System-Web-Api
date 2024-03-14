using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.Models.Users
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
