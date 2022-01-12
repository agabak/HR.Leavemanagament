using HR.Leavemanagament.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.DTOs
{
    public class UpdateLeaveTypeDto: BaseDto, ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
