using Moq;
using Domain.UserClassObjects;
using Microsoft.AspNetCore.Mvc;
using WebApi_SQL_SAMPLE.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Routing;
using WebApi_SQL_SAMPLE.Actions.QueryActions.UserQueryes;
using Domain.LoanClassObjects;
using System.Collections.Generic;

namespace WebApiTests
{
    [TestClass]
    public class UserControllerTest
    {
        private Mock<GetUserByUserId> userControllerMock = new Mock<GetUserByUserId>();
        private Mock<User> userMock = new Mock<User>();

        public void userControllerTest()
        {
            // It.IsAny<IActionResult>() - for any type of objects
            var userId = 12;
            
            {
                
            };
            userMock.Object.Id = 1;
            userMock.Object.FirstName = "giorgi";
            userMock.Object.LastName = "giorgi";
            userMock.Object.UserName = "giorgi";
            userMock.Object.Age = 41;
            userMock.Object.Email = "giorgi";
            userMock.Object.Salary = 5000;
            userMock.Object.Loans = new List<Loan>();

            userControllerMock.Setup(p => p.GetUserById(userId)).Returns(It.IsAny<User>());

            var iActionResultMock = new Mock<IActionResult>();
        }

        [TestMethod]
        public void ShouldReturnUserBySendedId()
        {
            var userId = 12;
            // arrange
            userControllerMock.Setup(p => p.GetUserById(userId)).Returns(It.IsAny<User>());

            // act
            //var result = controller.CheckOut(userMock.Object, addressInfoMock.Object);

            //// assert
            //shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items.AsEnumerable()), Times.Once());

            //Assert.AreEqual("charged", result);
        }
    }
}
