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
    [Route("Loan/[controller]")]
    public class LoanController : Controller
    {
        private readonly UserContext _context;
        public LoanController(UserContext context)
        {
            _context = context;
        }

        #region delete loan
        [HttpDelete("/Delete")]
        public IActionResult DeleteLoan(int loanId)
        {
            try
            {
                var validator = new IntValidator();
                if (validator.ValidateInt(loanId))
                {
                    var loan = _context.Loans.Find(loanId);
                    _context.Loans.Remove(loan);
                    _context.SaveChanges();
                    var loanList = _context.Loans.ToList();
                    return CreatedAtAction("GetAllLoans", loanList);
                }
                else
                {
                    return BadRequest("No loan found");
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

        #region Get All loan
        [HttpGet("/GetLoans")]
        public IActionResult GetAllLoans()
        {
            try
            {
                var loanList = _context.Loans.ToList();
                return loanList.Count() != 0 ? Ok(loanList) : Ok("No loans");
            }
            catch (Exception ex)
            {
                var logger = new LogError(_context);
                logger.Log(ex);
                return BadRequest(ex.Message);
            }
            
        }
        #endregion

        #region Get By Id
        [HttpGet("/GetLoanById")]
        public ActionResult<Loan> GetLoanByLoanId(int loanId)
        {
            try
            {
                var validator = new IntValidator();
                if (validator.ValidateInt(loanId))
                {
                    var loan = _context.Loans.Where(l => l.Id == loanId).FirstOrDefault();
                    return loan != null ? Ok(loan) : BadRequest("No loan found");
                }
                return BadRequest("invalid id");
            }
            catch (Exception ex)
            {
                var logger = new LogError(_context);
                logger.Log(ex);
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Get By User Id
        [HttpGet("/ByUserId")]
        public ActionResult<List<Loan>> GetLoanByUserId(int userId)
        {
            var validator = new IntValidator();
            if(validator.ValidateInt(userId))
            {
                try
                {
                    var loan = _context.Loans.Where(l => l.Id == userId).ToList();
                    if (loan.Count > 0)
                    {
                        return Ok(loan);
                    }
                    else
                    {
                        return Ok("No loan found");
                    }
                }
                catch (Exception ex)
                {
                    var logger = new LogError(_context);
                    logger.Log(ex);
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Invalid user id");
        }
        #endregion

        #region Create New Loan

        [HttpPost("/CreateNewLoan")]
        public IActionResult PostLoan([FromForm] Loan loan)
        {
            var validator = new LoanValidator();
            var validResult = validator.Validate(loan);
            if (validResult.IsValid)
            {
                try
                {
                    loan.Status = 0;
                    var user = _context.Users.Find(loan.UserId);
                    user.Loans.Add(loan);
                    _context.Users.Attach(user);
                    _context.SaveChanges();
                    return Ok(loan);
                }
                catch (Exception ex)
                {
                    var logger = new LogError(_context);
                    logger.Log(ex);
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(validResult.Errors[0].ErrorMessage);
        }
        #endregion

        #region Edit Loan

        [HttpPut("/EditLoan")]
        public IActionResult PuthLoan([FromForm] Loan loan)
        {
            var validator = new LoanValidator();
            var validResult = validator.Validate(loan);
            if(validResult.IsValid)
            {
                try
                {
                    if (_context.Loans.Find(loan.Id).Status == Status.Processing)
                    {
                        var user = _context.Users.Find(loan.UserId);
                        var index = user.Loans.FindIndex(s => s.Id == loan.Id);
                        user.Loans.Add(loan);
                        _context.Users.Update(user);
                        _context.SaveChanges();
                        var newloanList = _context.Loans.ToList();
                        return Ok(newloanList);
                    }
                    else
                    {
                        return BadRequest("You cannot edit a loan because it is approved or rejected");
                    }
                }
                catch (Exception ex)
                {
                    var logger = new LogError(_context);
                    logger.Log(ex);
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(validResult.Errors[0].ErrorMessage);
        }
        #endregion
    }
}
