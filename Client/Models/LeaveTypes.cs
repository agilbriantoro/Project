﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Client.Models;
[Table("tb_m_leave_type")]
public class LeaveTypes
{
    public int Id { get; set; }
    public string Name { get; set; }

}