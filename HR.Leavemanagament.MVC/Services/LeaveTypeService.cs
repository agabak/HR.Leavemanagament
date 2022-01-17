using AutoMapper;
using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using HR.Leavemanagament.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Services
{
    public class LeaveTypeService :BaseHttpService, ILeaveTypeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private IClient _httpClient;

        public LeaveTypeService(
            ILocalStorageService localStorageService,
            IMapper mapper, IClient httpClient) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<List<LeaveTypeVm>> GetLeaveTypes()
        {
            AddBearerToken();
            return _mapper.Map<List<LeaveTypeVm>>(await _client.LeaveTypeAllAsync());
        }

        public async Task<LeaveTypeVm> GetLeaveTypeWithDetails(int id)
        {
            AddBearerToken();
            return _mapper.Map<LeaveTypeVm>(await _client.LeaveTypeGETAsync(id));
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVm leaveType)
        {
            try
            {
                var response = new Response<int>();

                CreateLeaveTypeDto createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(leaveType);
                AddBearerToken();
                var apiResponse = await _client.LeaveTypePOSTAsync(createLeaveTypeDto);

                if(apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach(var error in apiResponse.Errors)
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

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                AddBearerToken();
                await _client.LeaveTypeDELETEAsync(id);

                return new Response<int>
                {
                    Success = true,
                    Message = "Deleted"
                };

            }catch(ApiException ex)
            {
                return ConvertApiExpceptions<int>(ex);
            }
        }

        public async Task<Response<int>> UpdateLeaveType(LeaveTypeVm leaveType)
        {
            try
            {
                var response = new Response<int>();

                UpdateLeaveTypeDto upateLeaveTypeDto = _mapper.Map<UpdateLeaveTypeDto>(leaveType);
                AddBearerToken();
                var apiResponse = await _client.LeaveTypePUTAsync(1,upateLeaveTypeDto);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                    response.Message = "Was updated";
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
              return  ConvertApiExpceptions<int>(ex);
            }
        }
    }
}
