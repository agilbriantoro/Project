using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Client.Models;

[Table("tb_m_countries")]

public class Countries
{
    public int Id { get; set; }
    public string Name { get; set; }
}
