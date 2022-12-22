using Data;
using System;

namespace WebApi_SQL_SAMPLE.Services
{
    public class LogError
    {
        private protected UserContext _context;
        public LogError(UserContext context) { _context = context; }
        public void Log(Exception ex)
        {
            var log = new CreateLogObjectFromExt();
            var error = log.CreateLogAndReturnIt(ex);
            _context.Logers.Add(error);
            _context.SaveChanges();
        }
    }
}
