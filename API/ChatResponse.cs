namespace OpenAIAssessment.API
{
    public class ChatResponse
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public long Created { get; set; }

        public string Model { get; set; }

        public List<CompletionChoice> Choices { get; set; }

        public UsageData Usage { get; set; }

        public class CompletionChoice
        {
            public string Text { get; set; }

            public int Index { get; set; }

            public object Logprobs { get; set; }

            public string FinishReason { get; set; }
        }

        public class UsageData
        {
            public int PromptTokens { get; set; }

            public int CompletionTokens { get; set; }

            public int TotalTokens { get; set; }
        }
    }
}
