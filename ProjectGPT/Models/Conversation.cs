namespace ProjectGPT.Models
{
    public class Conversation
    {
        public List<ConversationItem> ConversationHistory { get; set; } = new List<ConversationItem>();

        public void AddItem(string user, string message)
        {
            ConversationHistory.Add(new ConversationItem()
            {
                User = user,
                Message = message
            });
        }

        public void AppendToCurrentItem(string message)
        {
            this.ConversationHistory[this.ConversationHistory.Count - 1].Message += message;
        }
        public string GetCurrentItemMessage()
        {
           return this.ConversationHistory[this.ConversationHistory.Count - 1].Message;
        }
    }


    public class  ConversationItem
    {
        public string User { get; set; }
        public string Message { get; set; }

    }


    public class SearchModel
    {
        public string SearchText { get; set; }

        public string SystemContext  { get; set; }

        public string AssistantContext { get; set; }
    }
}
