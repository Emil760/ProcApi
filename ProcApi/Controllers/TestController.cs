using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProcApi.Services.Concreates;

namespace MyWebApi.Controllers
{
    public class TestController : Controller
    {
        private readonly IHubContext<ChatHub> chatHub;

        public TestController(IHubContext<ChatHub> chatHub)
        {
            this.chatHub = chatHub;
        }
    }
}
