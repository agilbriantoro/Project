using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models;

public class LeaveRequest
{
    public int Id { get; set; }

    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "Start Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Display(Name = "End Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EndDate { get; set; } = DateTime.Now;

    [Display(Name = "Descriptions")]
    public string? Descriptions { get; set; }

    [Display(Name = "Leave Day")]
    public int LeaveDay { get; set; }

    [Display(Name = "Leave Given")]
    public int LeaveGiven { get; set; }

    public string EmployeeNIK { get; set; }

    public int PositionId { get; set; }

    public int LeaveTypeId { get; set; }
}
