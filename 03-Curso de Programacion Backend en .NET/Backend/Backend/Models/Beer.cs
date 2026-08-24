using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Beer
    {
        [Key]  // Para que sea la PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // El primary key sera autoincrementable
        public int BeerId { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Alcohol { get; set; }

        [ForeignKey("BrandId")] // Crea la relacion con brandId, necesitas crear el metodo virtual para poder 
        public virtual Brand Brand { get; set; }
    }
}
