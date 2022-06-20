using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.User;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region CRUD

        [HttpGet]
        [ProducesResponseType(typeof(IList<UserResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] UserRequest user)
        {
            await _userService.Update(user);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Label), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _userService.GetOne(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] UserRequest user)
        {
            await _userService.Add(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
        [HttpGet("~/api/task/{taskId:int}/users")]
        [ProducesResponseType(typeof(IList<UserResponse>), (int)HttpStatusCode.OK)]
        public async Task<List<UserResponse>> GetUsersByTaskId([FromRoute] int taskId)
        {
            return await _userService.GetUsersByTaskId(taskId);
        }
        [HttpGet("~/api/board/{boardId:int}/users")]
        [ProducesResponseType(typeof(IList<UserResponse>), (int)HttpStatusCode.OK)]
        public async Task<List<UserResponse>> GetUsersByBoardId([FromRoute] int boardId)
        {
            return await _userService.GetUsersByBoardId(boardId);
        }

        #endregion
    }
}
