using Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi_SQL_SAMPLE.Services;
using WebApi_SQL_SAMPLE.Interfaces;
using WebApi_SQL_SAMPLE.Validators;

namespace WebApi_SQL_SAMPLE.Controllers
{
    public class LogController : Controller, ILogEvents
    {
        private readonly UserContext _context;

        public LogController(UserContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllLogs")]
        public IActionResult ReadAllErrors()
        {
            var logList = _context.Logers.ToList();
            return Ok(logList);
        }



        [HttpGet("GetLogById")]
        public IActionResult ReadErrorById(int logId)
        {
            var validator = new IntValidator();
            if(validator.ValidateInt(logId))
            {
                var result = _context.Logers.Find(logId);
                
                return result != null? Ok(result): BadRequest("No log find");
            }
            return BadRequest("Invalid id");
        }

        [HttpDelete("DeleteError")]
        public IActionResult DeleteLog(int logId)
        {
            var validator = new IntValidator();
            if (validator.ValidateInt(logId))
            {
                try
                {
                    var result = _context.Logers.Find(logId);
                    if (result != null)
                    {
                        _context.Logers.Remove(result);
                        _context.SaveChanges();
                        var logList = _context.Logers.ToList();
                        return Ok(logList);
                    }
                    return BadRequest("No log by this id");
                }
                catch (Exception ex)
                {
                    var logger = new LogError(_context);
                    logger.Log(ex);
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Invalid id");
        }
    }
}
