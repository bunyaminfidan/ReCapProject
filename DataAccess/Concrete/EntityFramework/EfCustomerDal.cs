using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCarProjectDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetail> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCarProjectDatabaseContext context = new ReCarProjectDatabaseContext())
            {
                var result = from customer in filter is null ? context.Customers : context.Customers.Where(filter)
                             join user in context.Users
                             on customer.Id equals user.Id

                             select new CustomerDetail
                             {
                                 Id = customer.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName
                             };
                return result.ToList();

            }
        }
    }
}
