using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.Application.Features;
using HR.Leavemanagament.Application.Profiles;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HR.Leavemanagament.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnityOfWork> _mockRepo;
        private readonly CreateLeaveTypeDto _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mappingConfigure = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mappingConfigure.CreateMapper();
            _handler = new  CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            _leaveTypeDto = new CreateLeaveTypeDto
            {
                DefaultDays = 15,
                Name = "Test DTO"
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
 
            var result = await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

            var leaveTypes = await _mockRepo.Object.leaveTypeRepository.GetAll();

            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_leaveType_Added()
        {
            _leaveTypeDto.DefaultDays = -1;

            ValidationException ex = await Should.ThrowAsync<ValidationException>
               (
                  async () =>
                       await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto }, CancellationToken.None)
               );

            var leaveTypes = await _mockRepo.Object.leaveTypeRepository.GetAll();

            leaveTypes.Count.ShouldBe(2);

            ex.ShouldNotBeNull();
        }
    }
}
