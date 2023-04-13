using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;
public class Employee
{
    public string NIK { get; set; }

    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "Birth Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }

    public GenderEnum Gender { get; set; }

    [Display(Name = "E-Mail")]
    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Hiring Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
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


