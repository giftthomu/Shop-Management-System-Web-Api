using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.Models.Users
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }
        public string usertype { get; set; }
    }
}
