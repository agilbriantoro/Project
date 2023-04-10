using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace API.Models;
[Table("tb_m_positions")]
public class Positions
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Required, Column("name")]
    public string Name { get; set; }

    // Cardinality 
    [JsonIgnore]
    public LeaveRequests? LeaveRequests { get; set; }

    [JsonIgnore]
    public Employee? Employees { get; set; }
}
