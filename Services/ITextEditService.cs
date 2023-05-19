namespace OpenAIAssessment.Services
{
    using OpenAIAssessment.API;

    public interface ITextEditService
    {
        public Task<TextEditResponse> GetAIResponse(string text, string instruction);
    }
}
