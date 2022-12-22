using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_SQL_SAMPLE_Test
{
    [TestClass]
    internal class TestPostUserMethod
    {
        [TestMethod]
        public void MustPutOneUserInDB()
        {
            var testUser = new User
            {
                FirstName = "TestName",
                LastName = "TestLastName",
                Age = 30,
                Email = "AA@Ggmail.com",
                Loans = new List<Loan>(),
                Salary = 3000,
                UserName = "TestUserName"
            };

            //var actual = 
        }
    }
}
