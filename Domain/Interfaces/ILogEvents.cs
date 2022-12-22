using Microsoft.AspNetCore.Mvc;

namespace WebApi_SQL_SAMPLE.Interfaces
{
    public interface ILogEvents
    {
        public IActionResult DeleteLog(int id);
        public IActionResult ReadAllErrors();
        public IActionResult ReadErrorById(int id);
    }
}
