using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Address_Id { get; set; }
}
