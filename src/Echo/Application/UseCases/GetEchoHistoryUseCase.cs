using System.Collections.Generic;
using System.Threading.Tasks;
using Echo.Domain;

namespace Echo.Application
{
    public class GetEchoHistoryUseCase
    {
        private readonly IEchoMessageRepository _echoRepository;

        public GetEchoHistoryUseCase(IEchoMessageRepository echoRepository)
        {
            _echoRepository = echoRepository;
        }

        public async Task<IEnumerable<EchoMessage>> ExecuteAsync()
        {
            var allMessages = await _echoRepository.GetAllAsync();

            return allMessages;
        }
    }
}