using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Comment.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [HasPermission(Permissions.CanGetComment)]
        public async Task<IActionResult> GetDocumentCommentsAsync([FromQuery] int documentId)
        {
            return Ok(await _commentService.GetDocumentCommentsAsync(documentId));
        }

        [HttpPost]
        [HasPermission(Permissions.CanAddComment)]
        public async Task<IActionResult> AddDocumentCommentAsync([FromBody] AddCommentRequest dto)
        {
            return Ok(await _commentService.AddDocumentCommentAsync(dto));
        }

        [HttpPut]
        [HasPermission(Permissions.CanAddComment)]
        public async Task<IActionResult> UpdateDocumentCommentAsync([FromQuery] int id)
        {
            return Ok(await _commentService.UpdateDocumentCommentAsync(id));
        }

        [HttpDelete]
        [HasPermission(Permissions.CanAddComment)]
        public async Task<IActionResult> DeleteDocumentCommentAsync([FromQuery] int id)
        {
            await _commentService.DeleteDocumentCommentAsync(id);
            return Ok();
        }
    }
}