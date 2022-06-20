using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.Assignment;

namespace ToDoApp.API.Controllers
{
    [Route("api/assignment")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        #region CRUD

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] AssignmentRequest assignment)
        {
            await _assignmentService.Add(assignment);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _assignmentService.Delete(id);
            return Ok();
        }

        [HttpDelete("~/api/user/{userId:int}/task/{taskId:int}/assignment")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteByUserIdAndTaskId(int userId, int taskId)
        {
            await _assignmentService.DeleteByUserIdAndTaskTd(userId,taskId);
            return Ok();
        }

        #endregion
    }
}
