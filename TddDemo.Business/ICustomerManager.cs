using System.Collections.Generic;
using TddDemo.Entities;

namespace TddDemo.Business
{
    public interface ICustomerManager
    {
        List<Customer> GetAll();
        int GetCountWithInitialLetter(string v);
    }
}