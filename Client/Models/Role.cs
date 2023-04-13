using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models;
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
}
