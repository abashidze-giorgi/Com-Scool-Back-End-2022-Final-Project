using Domain.Models;

namespace Domain.Interfaces
{
    public interface ILoan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Type Type { get; set; }
        public double Amount { get; set; }
        public LoanCurrency Currency { get; set; }
        public Status Status { get; set; }
        public int Period { get; set; }
        public User User { get; set; }
    }

}
