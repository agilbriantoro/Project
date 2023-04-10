using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace API.Models;

[Table("tb_m_departments")]
public class Departments
{
    [Key, Column("Id")]
    public int Id { get; set; }

    [Required, Column("Name")]
    public string Name { get; set; }

    [Required, Column("Address Id")]
    public int Address_Id { get; set; }

    // Cardinality & Relation
    [JsonIgnore]
    [ForeignKey(nameof(Address_Id))]
    public Addresses? Addresses { get; set; }

    [JsonIgnore]
    public ICollection<Employee>? Employees { get; set; }
}
