namespace OpenAIAssessment.WebAPIControllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using OpenAIAssessment.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class TextEditAPIController : ControllerBase
    {
        private readonly ITextEditService textEditService;

        public TextEditAPIController(ITextEditService textEditService)
        {
            this.textEditService = textEditService;
        }

        // POST api/<TextEditAPIController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(PostRequestDTO postRequestDTO)
        {
            var response = await this.textEditService.GetAIResponse(postRequestDTO.Text, postRequestDTO.Instruction);

            return this.Ok($"\"{response.Choices[0].Text.Trim()}\"");
        }

        public class PostRequestDTO
        {
            public string Text { get; set; }

            public string Instruction { get; set; }
        }
    }
}
