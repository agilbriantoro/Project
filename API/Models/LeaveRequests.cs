using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_tr_leave_requests")]
public class LeaveRequests
{
    [Key, Column("id")]
    public int Id { get; set; }

    //[Display(Name = "First Name")]
    [Required, Column("first_name"), MaxLength(50)]
    public string? FirstName { get; set; }

    //[Display(Name = "Last Name")]
    [Column("last_name"), MaxLength(50)]
    public string? LastName { get; set; }

    //[Display(Name = "Start Date")]
    [Required, Column("start_date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    //[Display(Name = "End Date")]
    [Required, Column("end_date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EndDate { get; set; } = DateTime.Now;

    //[Display(Name = "Descriptions")]
    [Column("descriptions"), MaxLength(255)]
    public string? Descriptions { get; set; }

    //[Display(Name = "Leave Day")]
    [Required, Column("leave_day")]
    public int LeaveDay { get; set; }

    //[Display(Name = "Leave Given")]
    [Required, Column("leave_given")]
    public int LeaveGiven { get; set; }

    [Required, Column("employee_nik", TypeName ="nchar(5)")]
    public string EmployeeNIK { get; set; }

    [Required, Column("position_id")]
    public int PositionsId { get; set; }

    [Required, Column("leave_type_id")]
    public int LeaveTypeId { get; set; }


    // Cardinality & Relations
    [JsonIgnore]
    [ForeignKey(nameof(EmployeeNIK))]
    public Employee? Employees { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(PositionsId))]
    public Positions? Positions { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(LeaveTypeId))]
    public LeaveTypes? LeaveTypes { get; set; }
}
