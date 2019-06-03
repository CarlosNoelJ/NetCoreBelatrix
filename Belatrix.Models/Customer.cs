using System.Collections.Generic;

namespace Belatrix.WebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public readonly List<Order> _order = new List<Order>();
        public IReadOnlyCollection<Order> Order => _order;
    }
}
