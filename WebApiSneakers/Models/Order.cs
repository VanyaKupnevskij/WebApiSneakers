using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiSneakers.Models.Base;

namespace WebApiSneakers.Models
{
    public class Order: BaseModel
    {
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public User User { get; set; }

        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }

        [Required]
        public int Count_product { get; set; }

        [Required]
        public DateTime Created_time { get; set; }

        [Required]
        public bool In_Basket { get; set; }
    }
}
