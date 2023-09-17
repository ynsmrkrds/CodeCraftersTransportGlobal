using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.MessagingContextApiClients;
using TransportGlobalWeb.UI.Models.RequestModels.MessagingContextRequestModels.Message;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.MessagingContextViewModels;

namespace TransportGlobalWeb.UI.Controllers
{
    public class MessageController : BaseController
    {
        private readonly MessageClient _messageClient;

        public MessageController(MessageClient messageClient)
        {
            _messageClient = messageClient;
        }

        public IActionResult GetMessagesByChatID(int id, int transportRequestID, int page = 0)
        {
            ApiResponseModel<ListResponseModel<MessageViewModel>>? apiResponse = _messageClient.GetMessagesByChatID(id, page);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            ViewData["Page"] = page;
            ViewData["ChatID"] = id;
            ViewData["TransportRequestID"] = transportRequestID;

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult CreateMessage(int chatID)
        {
            ViewData["ChatID"] = chatID;

            return View();
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageRequestModel createMessageRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _messageClient.CreateMessage(createMessageRequestModel);

            ViewData["ChatID"] = createMessageRequestModel.ChatID;

            return CreateActionResult(apiResponse, null);
        }
    }
}
