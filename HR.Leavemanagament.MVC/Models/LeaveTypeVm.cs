using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Models
{
    public class LeaveTypeVm: CreateLeaveTypeVm
    {
        public int Id { get; set; }
    }

    public class CreateLeaveTypeVm
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Number Of Days")]
        public int DefaultDays { get; set; }
    }

}
