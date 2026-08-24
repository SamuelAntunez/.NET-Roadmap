using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Brand
    {
        [Key]  // Para que sea la PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // El primary key sera autoincrementable
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
