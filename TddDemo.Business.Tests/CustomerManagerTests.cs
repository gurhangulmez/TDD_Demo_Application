using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TddDemo.DataAccess;
using TddDemo.Entities;

namespace TddDemo.Business.Tests
{
    /// <summary>
    /// Summary description for CustomerManagerTests
    /// </summary>
    [TestClass]
    public class CustomerManagerTests
    {
        Mock<ICustomerDal> mockCustomerDal;
        List<Customer> dbCustomers;

        [TestInitialize]
        public void Start()
        {
            mockCustomerDal = new Mock<ICustomerDal>();

            dbCustomers = new List<Customer>
            {
                new Customer{ Id = 1, FistName = "Gurhan" },
                new Customer{ Id = 2, FistName = "Aysegul" },
                new Customer{ Id = 3, FistName = "Naz" },
                new Customer{ Id = 4, FistName = "Ulug" },
                new Customer{ Id = 5, FistName = "Fazli" }
            };

            mockCustomerDal.Setup(m => m.GetAll()).Returns(dbCustomers);
        }

        [TestMethod]
        public void All_customers_can_be_listed()
        {
            //Arrange
            ICustomerManager cManager = new CustomerManager(mockCustomerDal.Object);

            //Act
            List<Customer> customers = cManager.GetAll();

            //Assert
            Assert.AreEqual(5, customers.Count);

        }

        [TestMethod]
        public void There_sould_be_one_customer_starts_with_G()
        {
            //Arrange

            ICustomerManager cManager = new CustomerManager(mockCustomerDal.Object);

            //Act
            int count = cManager.GetCountWithInitialLetter("G");

            //Assert
            Assert.AreEqual(count, 1);
        }
    }
}

//Customers should be listed
//Customers can be pageable by first letter

//Test case
//I will have a list with 5 element.

//Test case
//There should be only 1 customer that starts with 'G'