using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models;
[Table("tb_m_positions")]
public class Position
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Required, Column("name")]
    public string Name { get; set; }

    // Cardinality 
    [JsonIgnore]
    public LeaveRequest? LeaveRequest { get; set; }

    [JsonIgnore]
    public Employee? Employee { get; set; }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
