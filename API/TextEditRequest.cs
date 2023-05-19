namespace OpenAIAssessment.API
{
    using System.Text;

    public static class TextEditRequest
    {
        public static HttpRequestMessage GetAiTextFix(Uri remoteServiceBaseUrl, string text, string instruction)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = remoteServiceBaseUrl,
                Content = new StringContent(/*lang=json,strict*/
                    @"{
            ""model"": ""text-davinci-edit-001""," +
            $"\"input\": \"{text}\"," +
            $"\"instruction\": \"{instruction}\"," +
            @"""temperature"": 0.9,
            ""top_p"": 1
                    }",
                    Encoding.UTF8,
                    "application/json"),
            };
        }
    }
}
