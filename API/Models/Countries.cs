using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace API.Models
{
    [Table("tb_m_countries")]
    
    public class Countries
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("name"), MaxLength(50)]
        public string Name { get; set; }


        // Cardinality
        [JsonIgnore]
        public ICollection<Cities>? Cities { get; set; }
    }
}
