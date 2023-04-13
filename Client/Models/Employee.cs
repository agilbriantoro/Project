using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Client.Models;
[Table("tb_m_employees")]
public class Employee
{
    public string NIK { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderEnum Gender { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime HiringDate { get; set; } = DateTime.Now;
    public int DepartmentId { get; set; }
    public int PositionId { get; set; }
    public int AddressId { get; set; }
    public string? ManagerId { get; set; }

    public enum GenderEnum
    {
        Male,
        Female
    }
}


