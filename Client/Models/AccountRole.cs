using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models;

public class AccountRole
{
    public int Id { get; set; }

    public string AccountNIK { get; set; }

    public int RoleId { get; set; }
}
