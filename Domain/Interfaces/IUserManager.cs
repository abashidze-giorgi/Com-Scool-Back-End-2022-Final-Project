using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi_SQL_SAMPLE.Interfaces
{
    public interface IUserManager
    {
        List<User> GetUsers();
        List<User> GetUserByUserId(int id);
        bool PostUser([FromForm] User user);
        bool PuthUser([FromForm] User user);
        bool DeleteUser(int id);
    }
}
