using Data;
using System;
using System.Linq;
using Domain.Models;
using Domain.Validators;
using Microsoft.AspNetCore.Mvc;
using WebApi_SQL_SAMPLE.Services;
using System.Collections.Generic;
using WebApi_SQL_SAMPLE.Validators;

namespace WebApi_SQL_SAMPLE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private protected UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }

        #region Delete User

        [HttpDelete("/DeleteUser")]
        public ActionResult<List<User>> DeleteUser(int id)
        {
            try
            {
                var validator = new IntValidator();
                if (validator.ValidateInt(id))
                {
                    var user = _context.Users.Find(id);
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    var userList = _context.Users.ToList();
                    return CreatedAtAction("GetAllUsers", userList);
                }
                else
                {
                    return BadRequest("No user found");
                }
            }
            catch (Exception ex)
            {
                var logger = new LogError(_context);
                logger.Log(ex);
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Get all user
        [HttpGet("/GetAllUsers")]
        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                var addLoan = new AddLoanToUser();
                var userList = addLoan.AddLoansToUser(_context.Users.ToList(), _context.Loans.ToList());
                return userList.Count() != 0 ? Ok(userList) : BadRequest("No users");
            }
            catch (Exception ex)
            {
                var logger = new LogError(_context);
                logger.Log(ex);
                return BadRequest(ex.Message);
            }
            
        }
        #endregion

        #region Get user by id
        [HttpGet("/GetUserById")]
        public ActionResult<List<User>> GetUserByUserId(int userId)
        {
            try
            {
                var validator = new IntValidator();
                if (validator.ValidateInt(userId))
                {
                    var addLoan = new AddLoanToUser();
                    var user = addLoan.AddLoansToUser(_context.Users.ToList(), _context.Loans.ToList())
                        .Where(u => u.Id == userId);

                    return user.Count() != 0 ? Ok(user) : BadRequest("No User Found");
                }
                return BadRequest("Invalid id");
            }
            catch (Exception ex)
            {
                var logger = new LogError(_context);
                logger.Log(ex);
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Create user
        [HttpPost("/CreateUser")]
        public ActionResult<List<User>> PostUser([FromForm] User user)
        {
            try
            {
                var validator = new UserValidator();
                var validResult = validator.Validate(user);
                if (validResult.IsValid)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return CreatedAtAction("GetAllUsers", user);
                }
                return BadRequest(validResult.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {
                var logger = new LogError(_context);
                logger.Log(ex);
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Edit user
        [HttpPut("/EditUser")]
        public ActionResult<User> PutUser([FromForm] User user)
        {
            try
            {
                var validator = new UserValidator();
                var validResult = validator.Validate(user);
                if (validResult.IsValid)
                {
                    _context.Users.Update(user);
                    _context.SaveChanges();
                    return CreatedAtAction("GetAllUsers", user.Id, user);
                }
                return BadRequest(validResult.Errors[0].ErrorMessage);
            }
            catch (Exception ex)
            {
                var logger = new LogError(_context);
                logger.Log(ex);
                return BadRequest(ex.Message);
            }
            
        }
        #endregion
    }
}
