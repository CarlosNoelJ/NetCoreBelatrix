using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;
using System;

namespace Belatrix.WebApi.Tests.builder.data
{
    public partial class BelatrixDBContextBuilder: IDisposable
    {
        private BelatrixDbContext _context;
        public BelatrixDBContextBuilder ConfigureInMemory()
        {
            var options = new DbContextOptionsBuilder<BelatrixDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new BelatrixDbContext(options);
            return this;
        }

        public BelatrixDbContext Build()
        {
            return _context;
        }

        public void Dispose()
        {
        }
    }
}
