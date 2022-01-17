using HR.Leavemanagament.MVC.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Leavemanagament.MVC.Models
{

    public class LeaveRequestVm 
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        public DateTimeOffset StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTimeOffset EndDate { get; set; }

        public LeaveTypeDto LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        [Display(Name = "Date Requested")]
        public DateTimeOffset? DateRequested { get; set; }

        [Display(Name = "Comment :")]
        public string RequestComments { get; set; }

        public DateTimeOffset? DateActioned { get; set; }

        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }
    }

    public class UpdateLeaveRequestVm
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        public DateTimeOffset StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTimeOffset EndDate { get; set; }

        [Display(Name = "Comment :")]
        public string RequestComments { get; set; }

        public int LeaveTypeId { get; set; }

        public bool Cancelled { get; set; }
    }

    public class CreateLeaveRequestVm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
    }

    public class LeaveRequestListVm
    {
        public int Id { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public DateTimeOffset DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
