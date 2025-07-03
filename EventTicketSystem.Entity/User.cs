using System.ComponentModel.DataAnnotations.Schema;

namespace EventTicketSystem.Entity
{
    [Table("users")]
    public class User
    {
        [Column("userid")]
        public int UserId { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string PasswordHash { get; set; }

        public List<Purchase> Purchases{ get; set; } = new(); 
    }
}
