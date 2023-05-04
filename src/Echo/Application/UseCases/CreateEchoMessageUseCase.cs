using System.Threading.Tasks;
using Echo.Domain;

namespace Echo.Application
{
    public class CreateEchoMessageUseCase
    {
        private readonly IEchoMessageRepository _echoRepository;

        public CreateEchoMessageUseCase(IEchoMessageRepository echoRepository)
        {
            _echoRepository = echoRepository;
        }

        public async Task<EchoMessage> ExecuteAsync(string message)
        {
            var echo = EchoMessage.Create(message);

            await _echoRepository.AddAsync(echo);

            return echo;
        }
    }
}