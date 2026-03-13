using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GlutenFreeApi.Domains
{
    [Table("Places")]
    public class Place
    {
        public Place() 
        {
            Products = new Collection<Product>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? PlaceName { get; set; }
        [Required]
        [StringLength(300)]
        public string? PlaceDescription { get; set; }
        [Required]
        [StringLength(300)]
        public string? PlaceImageUrl { get; set; }
        [Required]
        [StringLength(100)]
        public string? PlaceAddress { get; set; }
        [Required]
        [StringLength(8)]
        public string? PlacePostalCode { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
