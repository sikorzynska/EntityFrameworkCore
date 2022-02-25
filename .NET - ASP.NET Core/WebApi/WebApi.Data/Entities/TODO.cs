using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities
{
    public class TODO
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public int PriorityId { get; set; }
        public Priority? Priority { get; set; }

        public int StatusId { get; set; }
        public Status? Status { get; set; }
    }
}
