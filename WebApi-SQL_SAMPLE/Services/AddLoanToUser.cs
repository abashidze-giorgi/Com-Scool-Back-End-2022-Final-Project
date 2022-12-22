using System.Linq;
using Domain.Models;
using System.Collections.Generic;

namespace WebApi_SQL_SAMPLE.Services
{
    public class AddLoanToUser
    {
        public List<User> AddLoansToUser(List<User> userList, List<Loan> loanList)
        {
            for (int i = 0; i < userList.Count(); i++)
            {
                var loan = loanList.Where(l => l.UserId == userList[i].Id).ToList();
                userList[i].Loans = loan;
                if (loan.Count > 0)
                {
                    userList[i].Loans = new List<Loan>(loan);
                }
            }
            return userList;
        }
    }
}
