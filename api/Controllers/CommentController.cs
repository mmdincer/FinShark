using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s=> s.ToCommentDto());
            
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
        {
            var commentModel = commentDto.ToCommentFromCreateDTO();
            await _commentRepo.CreateAsync(stockId ,commentModel);
            if (commentModel == null)
            {
                return NotFound();
            }
            return Created();
        }

        [HttpPut("{commentId}")]
        public async Task<IActionResult> Update([FromRoute] int commentId, [FromBody] CreateCommentDto commentDto)
        {
            var commentModel = commentDto.ToCommentFromCreateDTO();
            await _commentRepo.UpdateAsync(commentId, commentModel);
            if (commentModel == null)
            {
                return NotFound();
            }
            return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete("{comId}")]
        public async Task<IActionResult> Delete([FromRoute] int comId)
        {
            var commentModel = await _commentRepo.DeleteAsync(comId);
            if (commentModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}