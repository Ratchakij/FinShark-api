using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Contorllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepo;
    private readonly IStockRepository _stockRepo;
    public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
    {
        _commentRepo = commentRepo;
        _stockRepo = stockRepo;
    }

    [HttpGet]
    // [Authorize]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var comments = await _commentRepo.GetAllAsync();
        var commentDto = comments.Select(x => x.ToCommentDto());
        return Ok(commentDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var comment = await _commentRepo.GetByIdAsync(id);
        if (comment == null) { return NotFound(); }
        return Ok(comment.ToCommentDto());
    }

    [HttpPost("{stockId:int}")]
    // [Route("{symbol:alpha}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // var stock = await _stockRepo.GetBySymbolAsync(symbol);

        // if (stock == null)
        // {
        //     stock = await _fmpService.FindStockBySymbolAsync(symbol);
        //     if (stock == null)
        //     {
        //         return BadRequest("Stock does not exists");
        //     }
        //     else
        //     {
        //         await _stockRepo.CreateAsync(stock);
        //     }
        // }

        // var username = User.GetUsername();
        // var appUser = await _userManager.FindByNameAsync(username);

        if (!await _stockRepo.StockExists(stockId))
        {
            return BadRequest("Stock does not exists");
        }

        var commentModel = commentDto.ToCommentFromCreate(stockId);
        // commentModel.AppUserId = appUser.Id;
        await _commentRepo.CreateAsync(commentModel);
        return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto()); // ส่งคืน HTTP 201 Created พร้อมข้อมูลที่ถูกสร้าง
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate(id));

        if (comment == null) { return NotFound("Comment not found"); }

        return Ok(comment.ToCommentDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var commentModel = await _commentRepo.DeleteAsync(id);

        if (commentModel == null)
        {
            return NotFound("Comment does not exist");
        }

        return Ok(commentModel);
    }
}