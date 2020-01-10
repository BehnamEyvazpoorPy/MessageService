using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageSevice.Core;
using MessageSevice.Core.DefaultMessageSender;
using MessageSevice.Core.MessageModel;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task SendEmail(Email email) {
            await _messageSenderService.Send<EmailMessageSender, Email>(email);
        }
    }
}