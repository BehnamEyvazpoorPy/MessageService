using System.Threading.Tasks;
using MessageService.Core;
using MessageService.Core.Default;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageServiceController : ControllerBase
    {
        private readonly MessageSenderService _messageSenderService;

        public MessageServiceController(MessageSenderService messageSenderService)
        {
            _messageSenderService = messageSenderService;
        }

    }
}