using AutoMapper;
using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using HR.Leavemanagament.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Services
{
    public class LeaveRequestService :BaseHttpService, ILeaveRequestService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private IClient _httpClient;

        public LeaveRequestService(
            ILocalStorageService localStorageService,
            IMapper mapper, IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<List<LeaveRequestVm>> GetLeaveRequests()
        {
            return _mapper.Map<List<LeaveRequestVm>>(await _client.LeaveRequestAllAsync());
        }

        public async Task<LeaveRequestVm> GetLeaveRequestWithDetails(int id)
        {
            return _mapper.Map<LeaveRequestVm>(await _client.LeaveRequestGETAsync(id));
        }

        public async Task<Response<int>> CreateLeaveRequest(LeaveRequestVm leaveRequest)
        {
            try
            {
                var response = new Response<int>();

                CreateLeaveRequestDto createLeaveRequestDto = _mapper.Map<CreateLeaveRequestDto>(leaveRequest);
                var apiResponse = await _client.LeaveRequestPOSTAsync(createLeaveRequestDto);

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

        public async Task<Response<int>> DeleteLeaveRequest(int id)
        {
            try
            {
                await _client.LeaveRequestDELETEAsync(id);

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

        public async Task<Response<int>> UpdateLeaveRequest(UpdateLeaveRequestVm leaveType)
        {
            try
            {
                var response = new Response<int>();

                UpdateLeaveRequestDto updateLeaveRequestDto = _mapper.Map<UpdateLeaveRequestDto>(leaveType);
                var apiResponse = await _client.LeaveRequestPUTAsync(updateLeaveRequestDto);

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
