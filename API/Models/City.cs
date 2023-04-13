using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("tb_m_cities")]
    public class City
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("name")]
        public string Name { get; set; }

        [Required, Column("country_id")]
        public int CountryId { get; set; }

        // Cardinality & Relation
        [JsonIgnore]
        [ForeignKey(nameof(CountryId))]
        public Country? Country { get; set; }

        [JsonIgnore]
        public ICollection<Address>? Addresss { get; set; }
    }
}
