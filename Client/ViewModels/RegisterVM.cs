using System.ComponentModel.DataAnnotations;
using static Client.Models.Employee;

namespace Client.ViewModels;

public class RegisterVM
{
    [MaxLength(5), MinLength(5, ErrorMessage = "ex: 12345")]
    [Required(ErrorMessage = "Tidak Boleh Kosong ex: 12345")]
    public string NIK { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    public GenderEnum Gender { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Hiring Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime HiringDate { get; set; } = DateTime.Now;

    [Display(Name = "Birth Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }

    [Display(Name = "Department Name")]
    public string DepartmentName { get; set; }

    [Display(Name = "Position Name")]
    public string PositionName { get; set; }

    [Display(Name = "Address")]
    public string AddressName { get; set; }

    [Display(Name = "City")]
    public string CityName { get; set; }

    [Display(Name = "Postal Code")]
    public string PostalCode { get; set; }

    [Display(Name = "Country")]
    public string CountryName { get; set; }

    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; }

    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Not Match")]
    public string ConfirmPassword { get; set; }
}