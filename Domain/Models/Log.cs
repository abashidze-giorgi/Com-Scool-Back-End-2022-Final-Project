using System;
using Domain.Interfaces;

namespace Domain.Models
{
    public class Log : ILog
    {
        private int _id;
        private DateTime _createdDate = new DateTime();
        private string _name;
        private string _message;
        private string _helpLink;
        private string _stackTrace;
        private string _source;

        public int Id { get => _id; set => _id = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public string MethodName { get => _name; set => _name = value; }
        public string Message { get => _message; set => _message = value; }
        public string HelpLink { get => _helpLink; set => _helpLink = value; }
        public string StackTrace { get => _stackTrace; set => _stackTrace = value; }
        public string Source { get => _source; set => _source = value; }
    }
}
