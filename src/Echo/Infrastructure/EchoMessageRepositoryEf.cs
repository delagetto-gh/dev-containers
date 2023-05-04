using System.Collections.Generic;
using System.Threading.Tasks;
using Echo.Domain;
using Echo.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Echo
{
    public class EchoMessageRepositoryEf : IEchoMessageRepository
    {
        private readonly EchoDbContext _dbCtx;

        public EchoMessageRepositoryEf(EchoDbContext dbContext)
        {
            _dbCtx = dbContext;
        }

        public async Task AddAsync(EchoMessage echoMessage)
        {
            await _dbCtx.AddAsync(echoMessage);

            await _dbCtx.SaveChangesAsync();
        }

        public async Task<IEnumerable<EchoMessage>> GetAllAsync()
        {
            var res = await _dbCtx.Messages.ToListAsync();

            return res;
        }
    }
}