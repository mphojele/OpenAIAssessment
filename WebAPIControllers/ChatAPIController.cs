namespace OpenAIAssessment.WebAPIControllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using OpenAIAssessment.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class ChatAPIController : ControllerBase
    {
        private readonly IChatService chatService;

        public ChatAPIController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        // POST api/<ChatAPIController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            var response = await this.chatService.GetAIResponse(value);

            return this.Ok($"\"{response.Choices[0].Text.Trim()}\"");
        }
    }
}
