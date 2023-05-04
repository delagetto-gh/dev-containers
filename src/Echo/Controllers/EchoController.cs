using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Echo.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Echo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EchoController : ControllerBase
    {
        private readonly CreateEchoMessageUseCase _createEchoMessageUseCaseExecutor;
        private readonly GetEchoHistoryUseCase _getEchoMessageHistoryUseCaseExecutor;

        public EchoController(CreateEchoMessageUseCase createEchoMessageUseCaseExecutor,
                              GetEchoHistoryUseCase getEchoMessageHistoryUseCaseExecutor)
        {
            _createEchoMessageUseCaseExecutor = createEchoMessageUseCaseExecutor;
            _getEchoMessageHistoryUseCaseExecutor = getEchoMessageHistoryUseCaseExecutor;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string message)
        {
            var result = await _createEchoMessageUseCaseExecutor.ExecuteAsync(message);

            return Created(string.Empty, result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _getEchoMessageHistoryUseCaseExecutor.ExecuteAsync();

            return Ok(result);
        }
    }
}
