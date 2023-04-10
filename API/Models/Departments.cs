using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

[Table("tb_m_departments")]
public class Departments
{
    [Key, Column("Id")]
    public int Id { get; set; }
    [Required, Column("Name", TypeName = "nchar(50)")]
    public string Name { get; set; }
    [Required, Column("Address Id")]
    public int Address_Id { get; set; }
}
