using System.ComponentModel.DataAnnotations;
using WebApiSneakers.Models.Base;

namespace WebApiSneakers.Models
{
    public class User: BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string? Password { get; set; }
    }
}
