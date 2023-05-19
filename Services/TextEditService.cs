namespace OpenAIAssessment.Services
{
    using Newtonsoft.Json;

    using OpenAIAssessment.API;

    public class TextEditService : ITextEditService
    {
        private readonly HttpClient httpClient;

        public TextEditService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TextEditResponse> GetAIResponse(string text, string instruction)
        {
            var request = TextEditRequest.GetAiTextFix(this.httpClient.BaseAddress, text, instruction);

            var response = await this.httpClient.SendAsync(request);

            var content = JsonConvert.DeserializeObject<TextEditResponse>(await response.Content.ReadAsStringAsync());

            return content;
        }
    }
}
