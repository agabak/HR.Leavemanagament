using AutoMapper;
using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using HR.Leavemanagament.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private IClient _httpClient;

        public LeaveAllocationService(
            ILocalStorageService localStorageService,
            IMapper mapper, IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<List<LeaveAllocationVm>> GetLeaveAllocations()
        {
            return _mapper.Map<List<LeaveAllocationVm>>(await _client.LeaveAllocationGETAsync());
        }

        public async Task<LeaveAllocationVm> GetLeaveAllocationWithDetails(int id)
        {
            return _mapper.Map<LeaveAllocationVm>(await _client.LeaveAllocationGET2Async(id));
        }

        public async Task<Response<int>> CreateLeaveAllocation(CreateLeaveAllocationVm leaveAllocation)
        {
            try
            {
                var response = new Response<int>();

                CreateLeaveAllocationDto createLeaveAllocationDto = _mapper.Map<CreateLeaveAllocationDto>(leaveAllocation);
                var apiResponse = await _client.LeaveAllocationPOSTAsync(createLeaveAllocationDto);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExpceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveAllocation(int id)
        {
            try
            {
                await _client.LeaveAllocationDELETEAsync(id);

                return new Response<int>
                {
                    Success = true,
                    Message = "Deleted"
                };

            }
            catch (ApiException ex)
            {
                return ConvertApiExpceptions<int>(ex);
            }
        }

        public async Task<Response<int>> UpdateLeaveAllocation(LeaveAllocationVm leaveAllocation)
        {
            try
            {
                var response = new Response<int>();

                UpdateLeaveAllocationDto updateLeaveAllocationDto = _mapper.Map<UpdateLeaveAllocationDto>(leaveAllocation);
                var apiResponse = await _client.LeaveAllocationPUTAsync("1",updateLeaveAllocationDto);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExpceptions<int>(ex);
            }
        }
    }
}
