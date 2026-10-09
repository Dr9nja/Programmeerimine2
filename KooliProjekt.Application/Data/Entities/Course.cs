using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int Credits { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
