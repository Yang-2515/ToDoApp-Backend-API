using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.Board;
using ToDoApp.Domain.Models.BoardMember;
using ToDoApp.Domain.Models.ListTask;

namespace ToDoApp.API.Controllers
{
    [Route("api/board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        private readonly IListTaskService _listTaskService;
        private readonly IBoardMemberService _boardMemberService;
        public BoardController(IBoardService boardService,
            IListTaskService listTaskService,
            IBoardMemberService boardMemberService)
        {
            _boardService = boardService;
            _listTaskService = listTaskService;
            _boardMemberService = boardMemberService;
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
        [ProducesResponseType(typeof(BoardViewModel), (int)HttpStatusCode.OK)]
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

        [HttpPost("boardMember")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBoardMember([FromBody] BoardMemberRequest boardMember)
        {
            await _boardMemberService.Add(boardMember);
            return Ok();
        }

        [HttpDelete("boardMember")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBoardMember([FromQuery]int userId, [FromQuery] int boardId)
        {
            await _boardMemberService.DeleteByUserIdAndBoardTd(userId, boardId);
            return Ok();
        }

        #endregion
    }
}
