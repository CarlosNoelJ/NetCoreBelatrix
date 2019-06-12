using Belatrix.WebApi.Controllers;
using Belatrix.WebApi.Repository.Postgresql;
using Belatrix.WebApi.Tests.builder.data;
using FluentAssertions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [Fact]
        public async Task CustomerController_CreateCustomer_OK()
        {
            var db = _builder
                    .ConfigureInMemory()
                    .Build();

            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomerController(repository);

            var newCustomer = A.New<Models.Customer>();

            var response = (await controller.PostCustomer(newCustomer)).Result as OkObjectResult;

            var values = Convert.ToInt32(response.Value);

            values.Should().Be(newCustomer.Id);

        }
    }
}
