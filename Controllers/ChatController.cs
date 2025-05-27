using Microsoft.AspNetCore.Mvc;
using ChatSearchApi.Services;
using ChatSearchApi.Models;

namespace ChatSearchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            var results = _chatService.Search(keyword);
            return Ok(results);
        }

        [HttpPost("send")]
        public IActionResult Send([FromBody] ChatMessage message)
        {
            _chatService.Add(message);
            return Ok(new { status = "Message sent" });
        }
    }
}
