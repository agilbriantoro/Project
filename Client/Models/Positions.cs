using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Client.Models;
[Table("tb_m_positions")]
public class Positions
{
    public int Id { get; set; }
    public string Name { get; set; }
}
