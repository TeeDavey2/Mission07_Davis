using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Davis.Models
{
    public class MovieModel
    {

        [Key]
        [Required]
        public int MovieId { get; set; }


        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public CategoryModel? Category { get; set; }


        [Required(ErrorMessage ="Please enter a title.")]
        public string Title { get; set; }


        [Required(ErrorMessage ="Please enter a year after 1887.")]
        [Range(1888, 9999, ErrorMessage = "Please enter a year after 1887.")]
        public int Year { get; set; }


        public string? Director {  get; set; }


        public string? Rating { get; set; }


        [Required(ErrorMessage ="Please enter a value for 'Edited'")]
        public bool Edited { get; set; }


        public string? LentTo { get; set; }


        [Required(ErrorMessage = "Please enter a value for 'CopiedToPlex'")]
        public bool CopiedToPlex { get; set; }


        public string? Notes { get; set; }
    }
}
