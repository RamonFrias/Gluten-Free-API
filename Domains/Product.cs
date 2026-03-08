using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlutenFreeApi.Domains
{
    [Table("Products")]
    public class Product
    {
        public Product() 
        {
            ProductPlaces = new Collection<Place>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength( 80)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(300)]
        public string? ProductDescription { get; set; }
        [Required]
        [StringLength(20)]
        public string? ProductType { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }
        [Required]
        public int QuantityInStock { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public DateTime ProductionDate { get; set; }
        public ICollection<Place>? ProductPlaces { get; set; }

    }
}
