using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace API.Models
{
    [Table("tb_m_cities")]
    public class Cities
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("Name", TypeName = "nchar(50)")]
        public string Name { get; set; }
        [Required, Column("Country Id")]
        public int country_id { get; set; }
    }
}
