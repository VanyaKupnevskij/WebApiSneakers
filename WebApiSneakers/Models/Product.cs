using System.ComponentModel.DataAnnotations;
using WebApiSneakers.Models.Base;

namespace WebApiSneakers.Models
{
    public class Product: BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Preview { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
