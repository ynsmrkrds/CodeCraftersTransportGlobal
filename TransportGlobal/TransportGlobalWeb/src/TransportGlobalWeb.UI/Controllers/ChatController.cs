﻿using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.MessagingContextApiClients;
using TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Company;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.MessagingResponseModels.Chat;

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
            ApiResponseModel<GetOwnChatsResponseModel>? apiResponse = _chatClient.GetOwnChats(page);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            ViewData["Page"] = page;

            return CreateActionResult(apiResponse, onData);
        }
    }
}
