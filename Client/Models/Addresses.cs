using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;

[Table("tb_m_addresses")]
public class Addresses
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public int CityId { get; set; }
}
