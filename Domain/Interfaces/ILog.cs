using System;

namespace Domain.Interfaces
{
    public interface ILog
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string HelpLink { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
    }
}
