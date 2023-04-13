using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;
public class LeaveType
{
    public int Id { get; set; }
    public string Name { get; set; }
}