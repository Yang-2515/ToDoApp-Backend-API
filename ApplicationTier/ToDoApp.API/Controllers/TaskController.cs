using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.Task;

namespace ToDoApp.API.Controllers
{

    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        #region CRUD

        [HttpGet]
        [ProducesResponseType(typeof(IList<TaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _taskService.GetAll());
        }

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

        [HttpGet("~/api/listTask/{listTaskId:int}/tasks")]
        [ProducesResponseType(typeof(IList<TaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTasksByListTaskIdAsync(int listTaskId)
        {
            return Ok(await _taskService.GetTasksByListTaskIdAsync(listTaskId));
        }

        [HttpGet("~/api/task/{taskId:int}/subTasks")]
        [ProducesResponseType(typeof(IList<TaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSubTasksByTaskIdAsync(int taskId)
        {
            return Ok(await _taskService.GetSubTasksByTaskIdAsync(taskId));
        }

        [HttpPatch("")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateListTaskId([FromBody] TaskRequest task)
        {
            await _taskService.UpdateListTaskId(task);
            return Ok();
        }

        #endregion
    }
}
