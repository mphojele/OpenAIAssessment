namespace OpenAIAssessment.Services
{
    using Newtonsoft.Json;

    using OpenAIAssessment.API;

    public class ChatService : IChatService
    {
        private readonly HttpClient httpClient;

        public ChatService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ChatResponse> GetAIResponse(string aiPrompt)
        {
            var request = ChatRequest.GetAIAnswer(this.httpClient.BaseAddress, aiPrompt);

            var response = await this.httpClient.SendAsync(request);

            var chat = JsonConvert.DeserializeObject<ChatResponse>(await response.Content.ReadAsStringAsync());

            return chat;
        }
    }
}
