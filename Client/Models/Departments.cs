using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Client.Models;

[Table("tb_m_departments")]
public class Departments
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Address_Id { get; set; }
}
