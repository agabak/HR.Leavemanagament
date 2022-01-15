using AutoMapper;
using HR.Leavemanagament.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVm>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVm>().ReverseMap();
            CreateMap<UpdateLeaveTypeDto, LeaveTypeVm>().ReverseMap();

            CreateMap<LeaveRequestDto, LeaveRequestVm>().ReverseMap();
            CreateMap<CreateLeaveRequestDto, LeaveRequestVm>().ReverseMap();
            CreateMap<UpdateLeaveRequestDto, UpdateLeaveRequestVm>().ReverseMap();
            CreateMap<LeaveRequestListDto, LeaveRequestListVm>().ReverseMap();
            CreateMap<LeaveRequestDto, LeaveRequestVm>().ReverseMap();
            CreateMap<CreateLeaveRequestDto, CreateLeaveRequestVm>().ReverseMap();
            CreateMap<UpdateLeaveRequestVm, LeaveRequestVm>().ReverseMap();
            

            CreateMap<LeaveAllocationDto, LeaveAllocationVm>().ReverseMap();
            CreateMap<CreateLeaveAllocationDto, CreateLeaveAllocationVm>().ReverseMap();
            CreateMap<UpdateLeaveAllocationDto, LeaveAllocationVm>().ReverseMap();
        }
    }
}
