using Microsoft.AspNetCore.SignalR;
using ProcApi.Services.Concreates;

namespace ProcApi.Controllers
{
    public class TestController : BaseController
    {
        private readonly IHubContext<ChatHub> chatHub;

        public TestController(IHubContext<ChatHub> chatHub)
        {
            this.chatHub = chatHub;
        }
    }
}
