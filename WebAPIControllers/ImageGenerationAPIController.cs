namespace OpenAIAssessment.WebAPIControllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using OpenAIAssessment.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class ImageGenerationAPIController : ControllerBase
    {
        private readonly IImageGenerationService imageGenerationService;

        public ImageGenerationAPIController(IImageGenerationService imageGenerationService)
        {
            this.imageGenerationService = imageGenerationService;
        }

        // POST api/<TextEditAPIController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] string generationPrompt)
        {
            var response = await this.imageGenerationService.GetAIResponse(generationPrompt);

            return this.Ok($"\"{response.Data[0].Url.Trim()}\"");
        }
    }
}
