using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.BoardMember;

namespace ToDoApp.API.Controllers
{
    [Route("api/boardMember")]
    [ApiController]
    public class BoardMemberController : ControllerBase
    {
        private readonly IBoardMemberService _boardMemberService;
        public BoardMemberController(IBoardMemberService boardMemberService)
        {
            _boardMemberService = boardMemberService;
        }

        #region CRUD

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] BoardMemberRequest boardMember)
        {
            await _boardMemberService.Add(boardMember);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _boardMemberService.Delete(id);
            return Ok();
        }

        [HttpDelete("~/api/user/{userId:int}/board/{boardId:int}/boardMember")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteByUserIdAndBoardTd(int userId, int boardId)
        {
            await _boardMemberService.DeleteByUserIdAndBoardTd(userId, boardId);
            return Ok();
        }
        /*[HttpGet("{boardId:int}/Board")]
        [ProducesResponseType(typeof(IList<BoardMemberResponse>), (int)HttpStatusCode.OK)]
        public async Task<IList<BoardMemberResponse>> GetBoardMembersByBoardId(int boardId)
        {
            return await _boardMemberService.GetBoardMembersByBoardId(boardId);
        }*/

        #endregion
    }
}
