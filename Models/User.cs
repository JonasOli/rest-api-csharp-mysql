using System.ComponentModel.DataAnnotations;

namespace ex6.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
    }
}