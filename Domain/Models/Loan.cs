using Domain.Interfaces;

namespace Domain.Models
{
    public class Loan : ILoan
    {
        private int _id;
        private int _userId;
        private Type _type;
        private double _amount;
        private LoanCurrency _currency;
        private Status _status;
        private int _period;
        private User _user;
        public int Id { get => _id; set => _id = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public Type Type { get => _type; set => _type = value; }
        public double Amount { get => _amount; set => _amount = value; }
        public LoanCurrency Currency { get => _currency; set => _currency = value; }
        public Status Status { get => _status; set => _status = value; }
        public int Period { get => _period; set => _period = value; }
        public User User { get => _user; set => _user = value; }
    }
}
