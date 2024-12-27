using DemoService.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DemoService.Domain.Entities
{
    public class User : IIdentifiable<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public Guid AccountId { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime ModifyDate { get; set; } = DateTime.UtcNow;

        public Guid ApiKeyId { get; set; }

        public virtual ApiKey? ApiKey { get; set; }
    }
}
