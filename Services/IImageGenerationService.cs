namespace OpenAIAssessment.Services
{
    using OpenAIAssessment.API;

    public interface IImageGenerationService
    {
        public Task<ImageGenerationResponse> GetAIResponse(string prompt);
    }
}
