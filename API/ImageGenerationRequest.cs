namespace OpenAIAssessment.API
{
    using System.Text;

    public static class ImageGenerationRequest
    {
        public static HttpRequestMessage GetAiImage(Uri remoteServiceBaseUrl, string generationPrompt)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = remoteServiceBaseUrl,
                Content = new StringContent(
                    "{\"size\": \"1024x1024\"," +
                    $"\"prompt\": \"{generationPrompt}\"," +
                    "\"n\": 1}",
                    Encoding.UTF8,
                    "application/json"),
            };
        }
    }
}
