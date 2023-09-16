using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransportGlobalWeb.UI.ApiClients.MessagingContextApiClients;
using TransportGlobalWeb.UI.Models.ResponseModels.MessagingResponseModels.Chat;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.MessagingResponseModels.Message;
using TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Company;
using TransportGlobalWeb.UI.Models.RequestModels.MessagingContextRequestModels.Message;

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
            ApiResponseModel<GetMessagesByChatIDResponseModel>? apiResponse = _messageClient.GetMessagesByChatID(id, page);

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
