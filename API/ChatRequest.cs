namespace OpenAIAssessment.API
{
    using System.Text;

    public static class ChatRequest
    {
        public static HttpRequestMessage GetAIAnswer(Uri remoteServiceBaseUrl, string prompt)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = remoteServiceBaseUrl,
                Content = new StringContent(/*lang=json,strict*/
                    @"{
            ""model"": ""text-davinci-003""," +
            $"\"prompt\": \"{prompt}\"," +
            @"""temperature"": 0.9,
            ""max_tokens"": 150,
            ""top_p"": 1,
            ""frequency_penalty"": 0,
            ""presence_penalty"": 0.6,
            ""stop"": ["" Human:"", "" AI:""]
                    }",
                    Encoding.UTF8,
                    "application/json"),
            };
        }
    }
}
