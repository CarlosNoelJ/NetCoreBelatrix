using System.Collections.Generic;

namespace Belatrix.WebApi.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public readonly List<Product> _product = new List<Product>();
        public IReadOnlyCollection<Product> Product => _product;
    }
}