using System.ComponentModel.DataAnnotations;
using WebApiSneakers.Models.Base;

namespace WebApiSneakers.Models
{
    public class ChangePrice: BaseModel
    {
        [Required]
        public int Product_id { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime Date_time { get; set; }
    }
}
