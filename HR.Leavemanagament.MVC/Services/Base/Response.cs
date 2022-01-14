using System;

namespace HR.Leavemanagament.MVC.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; }
        public string ValidationErrors { get;  set; }
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}