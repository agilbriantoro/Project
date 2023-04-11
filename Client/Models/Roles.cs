using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models;

[Table("tb_m_roles")]
public class Roles
{
    public int Id { get; set; }
    public string Name { get; set; }
}
