using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class DeleteLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
