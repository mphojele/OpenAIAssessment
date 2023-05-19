namespace OpenAIAssessment.API
{
    public class ImageGenerationResponse
    {
        public long Created { get; set; }

        public List<UrlData> Data { get; set; }
    }

    public class UrlData
    {
        public string Url { get; set; }
    }
}
