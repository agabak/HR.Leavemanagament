﻿using AutoMapper;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Domain;

namespace HR.Leavemanagament.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();
        }
    }
}
