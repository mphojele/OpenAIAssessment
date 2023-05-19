namespace OpenAIAssessment.Services
{
    public class ChatService : IChatService
    {
        private readonly HttpClient httpClient;

        public ChatService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetAIResponse(string aiPrompt)
        {
            var request = API.ChatRequest.GetAIAnswer(this.httpClient.BaseAddress, aiPrompt);

            var response = await this.httpClient.SendAsync(request);

            return response;
        }
    }
}
