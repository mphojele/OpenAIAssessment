namespace OpenAIAssessment.Services
{
    using OpenAIAssessment.API;

    public interface IChatService
    {
        public Task<ChatResponse> GetAIResponse(string aiPrompt);
    }
}
