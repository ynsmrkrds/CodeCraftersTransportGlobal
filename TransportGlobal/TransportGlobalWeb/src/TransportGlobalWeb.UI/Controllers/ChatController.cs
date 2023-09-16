using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.MessagingContextApiClients;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.MessagingContextViewModels;

namespace TransportGlobalWeb.UI.Controllers
{
    public class ChatController : BaseController
    {
        private readonly ChatClient _chatClient;

        public ChatController(ChatClient chatClient)
        {
            _chatClient = chatClient;
        }

        public IActionResult GetOwnChats(int page = 0)
        {
            ApiResponseModel<ListResponseModel<ChatViewModel>>? apiResponse = _chatClient.GetOwnChats(page);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            ViewData["Page"] = page;

            return CreateActionResult(apiResponse, onData);
        }
    }
}
