namespace OpenAIAssessment.API
{
    public class TextEditResponse
    {
        public string Object { get; set; }

        public long Created { get; set; }

        public List<Choice> Choices { get; set; }

        public UsageData Usage { get; set; }
    }

    public class Choice
    {
        public string Text { get; set; }

        public int Index { get; set; }
    }

    public class UsageData
    {
        public int PromptTokens { get; set; }

        public int CompletionTokens { get; set; }

        public int TotalTokens { get; set; }
    }
}
