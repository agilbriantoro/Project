using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models;

[Table("tb_tr_leave_requests")]
public class LeaveRequests
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public string? Descriptions { get; set; }
    public int LeaveDay { get; set; }
    public int LeaveGiven { get; set; }
    public string EmployeeNIK { get; set; }
    public int PositionsId { get; set; }
    public int LeaveTypeId { get; set; }
}
