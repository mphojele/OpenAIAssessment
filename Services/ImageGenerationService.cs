namespace OpenAIAssessment.Services
{
    using Newtonsoft.Json;

    using OpenAIAssessment.API;

    public class ImageGenerationService : IImageGenerationService
    {
        private readonly HttpClient httpClient;

        public ImageGenerationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ImageGenerationResponse> GetAIResponse(string generationPrompt)
        {
            var request = ImageGenerationRequest.GetAiImage(this.httpClient.BaseAddress, generationPrompt);

            var response = await this.httpClient.SendAsync(request);

            var content = JsonConvert.DeserializeObject<ImageGenerationResponse>(await response.Content.ReadAsStringAsync());

            return content;
        }
    }
}
