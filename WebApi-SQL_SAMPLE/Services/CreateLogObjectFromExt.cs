using System;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_SQL_SAMPLE.Services
{
    public class CreateLogObjectFromExt : Controller
    {
        public Log CreateLogAndReturnIt(Exception ex)
        {
            var log = new Log()
            {
                CreatedDate = DateTime.Now,
                MethodName = ex.TargetSite.Name,
                Message = ex.Message,
                HelpLink = ex.HelpLink,
                StackTrace = ex.StackTrace,
                Source = ex.Source
            };
            return log;
        }
    }
}
