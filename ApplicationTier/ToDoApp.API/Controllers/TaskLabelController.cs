using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.TaskLabel;

namespace ToDoApp.API.Controllers
{
    [Route("api/taskLabel")]
    [ApiController]
    public class TaskLabelController : ControllerBase
    {
        private readonly ITaskLabelService _taskLabelService;
        public TaskLabelController(ITaskLabelService taskLabelService)
        {
            _taskLabelService = taskLabelService;
        }

        #region CRUD

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] TaskLabelRequest taskLabel)
        {
            await _taskLabelService.Add(taskLabel);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _taskLabelService.Delete(id);
            return Ok();
        }

        [HttpDelete("~/api/task/{taskId:int}/label/{labelId:int}/taskLabel")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteByTaskIdAndLabelId(int taskId, int labelId)
        {
            await _taskLabelService.DeleteByTaskIdAndLabelId(taskId, labelId);
            return Ok();
        }

        #endregion
    }
}
