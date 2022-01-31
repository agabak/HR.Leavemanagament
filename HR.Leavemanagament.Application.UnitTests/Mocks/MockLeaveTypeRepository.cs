using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Domain;
using Moq;
using System.Collections.Generic;

namespace HR.Leavemanagament.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<IUnityOfWork> GetLeaveTypeRepository()
        {

            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 15,
                    Name = "Test Sick"
                }
            };
            var mockRepo = new Mock<IUnityOfWork>();

            mockRepo.Setup(r => r.leaveTypeRepository.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.leaveTypeRepository.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
              id = 2;
              return   leaveTypes.Find(x => x.Id == id);
               
            });

            mockRepo.Setup(r => r.leaveTypeRepository.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockRepo;
        }
    }
}
