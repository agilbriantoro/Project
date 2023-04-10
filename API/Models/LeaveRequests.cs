using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_tr_leave_requests")]
public class LeaveRequests
{
    [Key, Column("Id")]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [Required, Column("first_name"), MaxLength(50)]
    public string? FirstName { get; set; }
    [Display(Name = "Last Name")]
    [Column("last_name"), MaxLength(50)]
    public string? LastName { get; set; }

    [Display(Name = "Start Date")]
    [Required, Column("start_date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime StartDate { get; set; } = DateTime.Now;
    
    [Display(Name = "End Date")]
    [Required, Column("end_date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EndDate { get; set; } = DateTime.Now;

    [Display(Name = "Descriptions")]
    [Column("descriptions", TypeName = "nchar(255)"), MaxLength(255)]
    public string Descriptions { get; set; }

    [Display(Name = "Leave Day")]
    [Required, Column("leave_day")]
    public int LeaveDay { get; set; }
    [Display(Name = "Leave Given")]
    [Required, Column("leave_given")]
    public int LeaveGiven { get; set;}

    [Required, Column("employee_NIK")]
    public string EmployeeNIK { get; set;}
    [Required, Column("positions_id")]
    public int PositionsId { get; set;}
    [Required, Column("leave_type_id")]
    public int LeaveTypeId { get; set;}

    

}
