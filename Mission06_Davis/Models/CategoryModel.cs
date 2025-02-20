using System.ComponentModel.DataAnnotations;

namespace Mission06_Davis.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<MovieModel> Movies { get; set; }

    }
}
