namespace OpenAIAssessment.Services
{
    public interface IChatService
    {
        public Task<HttpResponseMessage> GetAIResponse(string aiPrompt);
    }
}
