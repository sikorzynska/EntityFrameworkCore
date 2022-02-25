using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ToDoModel
    {
        [Required, MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Range(1, 3)]
        public int Priority { get; set; }

        [Range(1, 3)]
        public int Status { get; set; }
    }
}
