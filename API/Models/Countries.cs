using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [Table("tb_m_countries")]
    
    public class Countries
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        [Required, Column("Name", TypeName = "nchar(50)"), MaxLength(50)]
        public string Name { get; set; }

    }
}
