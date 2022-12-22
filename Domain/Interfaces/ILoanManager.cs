using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi_SQL_SAMPLE.Actions
{
    public interface ILoanManager
    {
        bool DeleteLoan(int loanId);
        bool DeleteLoan(Loan loan);
        List<Loan> GetLoanByUserId(int userId);
        List<Loan> GetLoanByLoanId(int loanId);
        List<Loan> GetLoans();
        bool PuthLoan([FromForm]Loan loan); 
        bool PostLoan([FromForm]Loan loan);
    }
}
