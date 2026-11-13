using System.ComponentModel.DataAnnotations;

namespace JwtAuthWeb.Entities
{
    public class User
    {
       
        public Guid id { get; set; }
        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Roles { get; set; } = string.Empty;

        public string RefreshTocken { get; set; } = string.Empty;

        public DateTime RefreshTockenExpiry { get; set; }
        public int Active { get; set; } 

    }
}
