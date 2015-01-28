using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityLibrary
{
    public class CustomerRepository
    {
        private OrderRequestEntities database = new OrderRequestEntities();

        public void Save(Customer customer)
        {
            database.Customers.Add(customer);
            database.SaveChanges();
        }

        public Boolean IsEmailExist(string EmailAddress)
        {
            var result = database.Customers.Where(customer => customer.EmailAddress == EmailAddress).ToList();
            return result.Count > 0;
        }



        
    }
}
