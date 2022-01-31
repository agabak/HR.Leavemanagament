using System;

namespace HR.Leavemanagament.Application.Exceptions
{
    public class NotFoundException: ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} of {key} was not found")
        {
        }
    }
}
