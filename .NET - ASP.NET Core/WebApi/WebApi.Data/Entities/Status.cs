using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string? Title { get; set; }
    }
}
