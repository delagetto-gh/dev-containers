using System.Collections.Generic;
using System.Threading.Tasks;

namespace Echo.Domain
{
    public interface IEchoMessageRepository
    {
        Task AddAsync(EchoMessage echoMessage);
        Task<IEnumerable<EchoMessage>> GetAllAsync();
    }
}