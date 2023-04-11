using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Client.Models;

[Table("tb_m_cities")]
public class Cities
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
}
