using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace API.Models
{
    [Table("tb_m_cities")]
    public class Cities
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("name")]
        public string Name { get; set; }

        [Required, Column("country_id")]
        public int CountryId { get; set; }

        // Cardinality & Relation
        [JsonIgnore]
        public Countries? Countries { get; set; }

        [JsonIgnore]
        public ICollection<Addresses>? Addresss { get; set; }
    }
}
