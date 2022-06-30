using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.Assignment;
using ToDoApp.Domain.Models.Attackment;
using ToDoApp.Domain.Models.Task;
using ToDoApp.Domain.Models.TaskLabel;

namespace ToDoApp.API.Controllers
{

    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IAssignmentService _assignmentService;
        private readonly IAttackmentService _attackmentService;
        private readonly ITaskLabelService _taskLabelService;
        public TaskController(ITaskService taskService,
            IAssignmentService assignmentService,
            IAttackmentService attackmentService,
            ITaskLabelService taskLabelService)
        {
            _taskService = taskService;
            _assignmentService = assignmentService;
            _attackmentService = attackmentService;
            _taskLabelService = taskLabelService;
        }

        #region CRUD

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] TaskRequest task)
        {
            await _taskService.Update(task);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TaskResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _taskService.GetOne(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] TaskRequest task)
        {
            await _taskService.Add(task);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _taskService.Delete(id);
            return Ok();
        }

        [HttpPatch("")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateListTaskId([FromBody] TaskRequest task)
        {
            await _taskService.UpdateListTaskId(task);
            return Ok();
        }
        [HttpPost("assignment")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddAssignment([FromBody] AssignmentRequest assignment)
        {
            await _assignmentService.Add(assignment);
            return Ok();
        }

        [HttpDelete("assignment")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAssignment([FromQuery] int userId, [FromQuery] int taskId)
        {
            await _assignmentService.DeleteByUserIdAndTaskTd(userId, taskId);
            return Ok();
        }

        [HttpPost("attackment")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddAttackment([FromBody] AttackmentRequest assignment)
        {
            await _attackmentService.Add(assignment);
            return Ok();
        }

        [HttpDelete("attackment")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAttackment([FromQuery] int id)
        {
            await _attackmentService.Delete(id);
            return Ok();
        }

        [HttpPost("taskLabel")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddLabel([FromBody] TaskLabelRequest taskLabel)
        {
            await _taskLabelService.Add(taskLabel);
            return Ok();
        }

        [HttpDelete("taskLabel")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLabel([FromQuery] int taskId, [FromQuery] int labelId)
        {
            await _taskLabelService.DeleteByTaskIdAndLabelId(taskId, labelId);
            return Ok();
        }
        #endregion
    }
}
