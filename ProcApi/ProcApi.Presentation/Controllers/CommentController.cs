using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Comment;
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
        public async Task<IActionResult> GetCommentAsync([FromQuery] int documentId)
        {
            return Ok();
        }

        [HttpPost]
        [HasPermission(Permissions.CanAddComment)]
        public async Task<IActionResult> AddCommentAsync([FromBody] AddCommentRequestDto dto)
        {
            return Ok();
        }

        [HttpPut]
        [HasPermission(Permissions.CanAddComment)]
        public async Task<IActionResult> UpdateCommentAsync([FromQuery] int id)
        {
            return Ok();
        }

        [HttpDelete]
        [HasPermission(Permissions.CanAddComment)]
        public async Task<IActionResult> DeleteCommentAsync([FromQuery] int id)
        {
            return Ok();
        }
    }
}