using Belatrix.WebApi.Controllers;
using Belatrix.WebApi.Repository.Postgresql;
using Belatrix.WebApi.Tests.builder.data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Belatrix.WebApi.Tests
{
    public class CustomerControllerTests
    {
        private readonly BelatrixDBContextBuilder _builder;

        public CustomerControllerTests()
        {
            _builder = new BelatrixDBContextBuilder();
        }

        [Fact]
        public async Task CustomerController_GetCustomer_OK()
        {
            var db = _builder.ConfigureInMemory().AddTenCustomers().Build();

            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomerController(repository);

            var response = (await controller.GetCustomers()).Result as OkObjectResult;

            var values = response.Value as List<Models.Customer>;

            values.Count.Should().Be(10);
        }
    }
}
