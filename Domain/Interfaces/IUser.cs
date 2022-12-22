using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
