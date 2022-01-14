using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Features;
using HR.Leavemanagament.Application.Profiles;
using HR.Leavemanagament.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HR.Leavemanagament.Application.UnitTests.LeaveRequests.Queries
{
    public class GetLeaveRequestRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveRequestResposity> _mockRepo;

        public GetLeaveRequestRequestHandlerTests()
        {
            _mockRepo = MockLeaveRequestRepository.GetLeaveRequestRepository();
            var mappingConfigure = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mappingConfigure.CreateMapper();
        }


        [Fact]
        public async Task GetLeaveTypeDetail()
        {
            var handler = new GetLeaveRequestRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetLeaveRequestRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveRequestListDto>>();

            result.Count.ShouldBe(2);

            result.FirstOrDefault().Id.ShouldBe(1);
        }

    }
}
