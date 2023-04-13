using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;

[Table("tb_m_departments")]
public class Department
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
<<<<<<< Updated upstream
    public Address? Address { get; set; }
=======
    public Addresses? Addres { get; set; }
>>>>>>> Stashed changes

    [JsonIgnore]
    public ICollection<Employee>? Employees { get; set; }
}
