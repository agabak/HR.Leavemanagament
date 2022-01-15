using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Features;
using HR.Leavemanagament.Application.Profiles;
using HR.Leavemanagament.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HR.Leavemanagament.Application.UnitTests.LeaveTypes.Commands
{
    public class GetLeaveTypeDetailRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;

        public GetLeaveTypeDetailRequestHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mappingConfigure = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mappingConfigure.CreateMapper();
        }


        [Fact]
        public async Task GetLeaveTypeDetail()
        {
            var handler = new GetLeaveTypeDetailRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetLeaveTypeDetailRequest(), CancellationToken.None);

            result.ShouldBeOfType<LeaveTypeDto>();

            result.Name.ShouldBe("Test Sick");

            result.DefaultDays.ShouldBe(15);
        }
    }
}
