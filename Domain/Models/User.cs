using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.Models
{
    public class User : IUser
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private int _age;
        private string _email;
        private int _salaryary;
        private List<Loan> _loans = new List<Loan>();
        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public int Age { get => _age; set => _age = value; }
        public string Email { get => _email; set => _email = value; }
        public int Salary { get => _salaryary; set => _salaryary = value; }
        public List<Loan> Loans { get => _loans; set => _loans = value; }
    }
}
