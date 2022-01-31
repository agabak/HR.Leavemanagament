using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Domain;
using Moq;
using System;
using System.Collections.Generic;

namespace HR.Leavemanagament.Application.UnitTests.Mocks
{
    public static class MockLeaveRequestRepository
    {

        public static Mock<IUnityOfWork>  GetLeaveRequestRepository()
        {
            var leaveRequests = new List<LeaveRequest>
            {
                new LeaveRequest
                {
                    Id = 1,
                    StartDate = DateTime.Now,
                    EndDate  = DateTime.Now.AddDays(4),
                    LeaveType = new LeaveType { Id = 1 },
                    LeaveTypeId = 1,
                    DateCreated = DateTime.Now,
                    RequestComments = "I sure need a day off",
                    DateActioned = DateTime.Now,
                    Approved = false,
                    Cancelled = false
                },
               new LeaveRequest
                {
                    Id = 2,
                    StartDate = DateTime.Now,
                    EndDate  = DateTime.Now.AddDays(4),
                    LeaveType = new LeaveType { Id = 2 },
                    LeaveTypeId = 2,
                    DateCreated = DateTime.Now,
                    RequestComments = "I sure need a day off",
                    DateActioned = DateTime.Now,
                    Approved = false,
                    Cancelled = false
                },
            };
            var mockRepo = new Mock<IUnityOfWork>();

            mockRepo.Setup(r => r.leaveRequestResposity.GetAll()).ReturnsAsync(leaveRequests);

            mockRepo.Setup(r => r.leaveRequestResposity.GetLeaveRequestWithDetails()).ReturnsAsync(leaveRequests);

            mockRepo.Setup(r => r.leaveRequestResposity.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return leaveRequests.Find(x => x.Id == 2);

            });

            mockRepo.Setup(r => r.leaveRequestResposity.GetLeaveRequestWithDetail(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return leaveRequests.Find(x => x.Id == 2);
            });

            mockRepo.Setup(r => r.leaveRequestResposity.Add(It.IsAny<LeaveRequest>())).ReturnsAsync((LeaveRequest leaveRequest) =>
            {
                leaveRequests.Add(leaveRequest);
                return leaveRequest;
            });

            return mockRepo;
        }
    }
}
