// File: Services/ChatService.cs
using ChatSearchApi.Models;

namespace ChatSearchApi.Services
{
    public class ChatService
    {
        private readonly List<ChatMessage> _chatMessages = new();

        public ChatService()
        {
            _chatMessages.Add(new ChatMessage { Id = 1, Sender = "User1", Message = "Hello", Timestamp = DateTime.Now });
        }

        public IEnumerable<ChatMessage> Search(string keyword)
        {
            return _chatMessages
                .Where(msg => msg.Message.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(ChatMessage message)
        {
            message.Id = _chatMessages.Count + 1;
            message.Timestamp = DateTime.Now;
            _chatMessages.Add(message);
        }
    }
}
