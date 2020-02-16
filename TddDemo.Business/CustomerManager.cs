using System.Collections.Generic;
using System.Linq;
using TddDemo.DataAccess;
using TddDemo.Entities;

namespace TddDemo.Business
{
    public class CustomerManager : ICustomerManager
    {
        ICustomerDal customerDal;

        public CustomerManager(ICustomerDal _customerDal)
        {
            customerDal = _customerDal;
        }

        public List<Customer> GetAll()
        {
            return customerDal.GetAll();
        }

        public int GetCountWithInitialLetter(string initial)
        {
            return customerDal.GetAll().Where(c => c.FistName.StartsWith(initial)).Count<Customer>();
        }
    }
}