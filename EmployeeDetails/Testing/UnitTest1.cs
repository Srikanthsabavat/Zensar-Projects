using EmployeeDetails.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeDetails.Models;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new EmployeeController();
            MyClass emp = new MyClass
            {
                EmpType = "Permanent",
            };
            //Act On Test
            IHttpActionResult acr = controller.AddEmp(emp);
            var empl = acr as OkNegotiatedContentResult<MyClass>;
            //Assert the result
            Assert.IsNotNull(empl);
            Assert.IsNotNull(empl.Content);
            Assert.AreEqual("Eligible", empl.Content.Bonus_Status);

        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            var controller = new EmployeeController();
            MyClass emp = new MyClass
            {
                EmpType = "Contractor",
            };
            //Act On Test
            IHttpActionResult acr = controller.AddEmp(emp);
            var empl = acr as OkNegotiatedContentResult<MyClass>;
            //Assert the result
            Assert.IsNotNull(empl);
            Assert.IsNotNull(empl.Content);
            Assert.AreEqual("Not-Eligible", empl.Content.Bonus_Status);
        }
        [TestMethod]
        public void TestMethod3()
        {
            // Arrange  
            var controller = new EmployeeController();
            // Act on Test  
            var response = controller.GetEmpById(201);
            var cr = response as OkNegotiatedContentResult<MyClass>;
            // Assert the result  
            Assert.IsNotNull(cr);
            Assert.IsNotNull(cr.Content);
            Assert.AreEqual("srikanth", cr.Content.FirstName);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            var controller = new EmployeeController();
            MyClass emp = new MyClass
            {
                Address = "Hyderabad",
            };
            //Act on test
            IHttpActionResult res = controller.AddAddres(201, emp);
            var cr = res as NegotiatedContentResult<MyClass>;
            // Assert the result 
            Assert.IsNotNull(cr);
            Assert.AreEqual(HttpStatusCode.Accepted, cr.StatusCode);
            Assert.IsNotNull(cr.Content);
        }

    }
}
