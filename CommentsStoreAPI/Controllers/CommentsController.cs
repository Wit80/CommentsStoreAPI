using CommentsStoreAPI.Models;
using CommentsStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace CommentsStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController:ControllerBase
    {
        private readonly CommentsService _commentsService;

        public CommentsController(CommentsService commentsService)
        {
            this._commentsService = commentsService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<List<Commentary>> Get()
            => await _commentsService.GetAsync();

        

        [HttpPost]
        [EnableQuery]
        public async Task<IActionResult> Post([FromODataUri] Commentary newComment)
        {
            await _commentsService.CreateAsync(newComment);
            return CreatedAtAction(nameof(Get), new { id = newComment.Id}, newComment);
        }
        [HttpPut("{id:length(24)}")]
        [EnableQuery]
        public async Task<IActionResult> Put([FromODataUri] string id, Commentary updatedComment) 
        {
            var comment = _commentsService.GetAsync(id);
            if (comment is null) 
            {
                return NotFound();
            }
            updatedComment.Id = comment.Id.ToString();
            await _commentsService.UpdateAsync(id, updatedComment);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [EnableQuery]
        public async Task<IActionResult> Delete([FromODataUri] string id) 
        {
            var comment = await _commentsService.GetAsync(id);
            if (comment is null)
            {
                return NotFound();
            }
            await _commentsService.DeleteAsync(id);

            return NoContent();

        }
    }

    
}
