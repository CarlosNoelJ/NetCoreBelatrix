using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace Belatrix.WebApi.Tests.builder.data
{
    public partial class BelatrixDBContextBuilder
    {
        private BelatrixDbContext _context;
        public BelatrixDBContextBuilder ConfigureInMemory()
        {
            var options = new DbContextOptionsBuilder<BelatrixDbContext>()
                .UseInMemoryDatabase("test_base")
                .Options;

            _context = new BelatrixDbContext(options);
            return this;
        }

        public BelatrixDbContext Build()
        {
            return _context;
        }
    }
}
