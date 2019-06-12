using Belatrix.WebApi.Repository.Postgresql;
using GenFu;

namespace Belatrix.WebApi.Tests.builder.data
{
    public partial class BelatrixDBContextBuilder
    {
        public BelatrixDBContextBuilder AddTenCustomers()
        {
            AddCustomer(_context,10);
            return this;
        }

        private void AddCustomer(BelatrixDbContext context, int quantity)
        {
            var customerList = A.ListOf<Models.Customer>(10);

            for(int i=1; i<= quantity; i++)
            {
                customerList[i - 1].Id = i;
            }

            context.Customer.AddRange(customerList);
            context.SaveChanges();
        }
    }
}
