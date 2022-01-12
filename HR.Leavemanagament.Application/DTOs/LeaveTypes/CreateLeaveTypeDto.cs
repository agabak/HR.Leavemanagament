namespace HR.Leavemanagament.Application.DTOs
{
    public class CreateLeaveTypeDto: ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
