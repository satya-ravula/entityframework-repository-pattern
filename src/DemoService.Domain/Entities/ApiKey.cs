using DemoService.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DemoService.Domain.Entities
{
    public class ApiKey : IIdentifiable<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public string? Secret { get; set; }

        [Required]
        public string? AdminUsername { get; set; }

        [Required]
        public Guid AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ExpiresAt { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime ModifyDate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
