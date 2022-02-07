using HR.Leavemanagament.MVC.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.Leavemanagament.MVC.Models
{

    public class LeaveRequestVM : CreateLeaveRequestVM
    {
        public int Id { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }

        [Display(Name = "Approval State")]
        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }
        public LeaveTypeVm LeaveType { get; set; }
        public EmployeeVM Employee { get; set; }

    }

    public class CreateLeaveRequestVM
    {

        [Display(Name = "Start Date")]
        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required]
        public DateTimeOffset EndDate { get; set; }

        public SelectList LeaveTypes { get; set; }

        [Display(Name = "Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }

        [Display(Name = "Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
    } 

    public class ChangeLeaveRequestApprovalVM
    {
        public int Id { get; set; }
        public bool Approval { get; set; }
    }
}
