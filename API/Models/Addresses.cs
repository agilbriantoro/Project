using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [Table("tb_m_addresses")]
    public class Addresses
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required , Column ("Address", TypeName = "nchar(50)")]
        public string Address { get; set; }
        [Required, Column("Postal Code", TypeName = "nchar(10)")]
        public string Postal_Code { get; set; }
        [Required, Column("City Id")]
        public int City_Id { get; set; }
    }
}
