using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities
{
    public class Priority
    {
        [Key]
        public int PriorityId { get; set; }

        [Required]
        public string? Title { get; set; }
    }
}
