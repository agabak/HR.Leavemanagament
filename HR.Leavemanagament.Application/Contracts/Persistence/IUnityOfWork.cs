using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Contracts.Persistence
{
    public interface IUnityOfWork
    {
        ILeaveAllocationRepository leaveAllocationRepository { get; }

        ILeaveRequestResposity leaveRequestResposity { get;  }

        ILeaveTypeRepository leaveTypeRepository { get; }

        Task SaveChanges();
    }
}
