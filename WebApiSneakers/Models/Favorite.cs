using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiSneakers.Models.Base;

namespace WebApiSneakers.Models
{
    public class Favorite : BaseModel
    {
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public User User { get; set; }

        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
    }
}
