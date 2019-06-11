using Belatrix.WebApi.Repository.Postgresql;
using GenFu;

namespace Belatrix.WebApi.Tests.builder.data
{
    public partial class BelatrixDBContextBuilder
    {
        public BelatrixDBContextBuilder AddTenCustomers()
        {
            AddCustomer(_context);
            return this;
        }

        private void AddCustomer(BelatrixDbContext context)
        {
            var customerList = A.ListOf<Models.Customer>(10);
            context.Customer.AddRange(customerList);
            context.SaveChanges();
        }
    }
}
