using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Users
    {
        [Key]
        public int UserId       { get; set; }
        public string UserName  { get; set; }
        public string Email     { get; set; }
        public string Password  { get; set; }
    }
}
