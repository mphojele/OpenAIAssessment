using OpenAIAssessment.API;

namespace OpenAIAssessment.Services
{
    public interface IChatService
    {
        public Task<ChatResponse> GetAIResponse(string aiPrompt);
    }
}
