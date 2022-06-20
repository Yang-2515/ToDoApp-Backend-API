using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.Board;

namespace ToDoApp.API.Controllers
{
    [Route("api/board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        #region CRUD

        [HttpGet]
        [ProducesResponseType(typeof(IList<BoardResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _boardService.GetAll());
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] BoardRequest board)
        {
            await _boardService.Update(board);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BoardResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _boardService.GetOne(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] BoardRequest label)
        {
            await _boardService.Add(label);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _boardService.Delete(id);
            return Ok();
        }

        [HttpGet("manage/{manageId:int}")]
        [ProducesResponseType(typeof(IList<BoardResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBoardsByManageId(int manageId)
        {
            return Ok(await _boardService.GetBoardsByManageId(manageId));
        }

        [HttpGet("~/api/user/{userId:int}/boards")]
        [ProducesResponseType(typeof(IList<BoardResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBoardsByUserIdAsync(int userId)
        {
            return Ok(await _boardService.GetBoardsByUserIdAsync(userId));
        }

        #endregion
    }
}
