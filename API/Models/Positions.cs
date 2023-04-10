using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models;
[Table("tb_m_positions")]
public class Positions
{
    [Key, Column("Id")]
    public int Id { get; set; }
    [Required, Column("Name")]
    public string Name { get; set; }
}
