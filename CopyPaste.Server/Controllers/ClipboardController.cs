using CopyPaste.Server.Features.Clipboard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CopyPaste.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClipboardController(ILogger<ClipboardController> logger, IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<ClipboardController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> GetClipboardData([FromQuery] GetClipboardDataRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> StoreClipboardData([FromBody] StoreClipboardDataCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
