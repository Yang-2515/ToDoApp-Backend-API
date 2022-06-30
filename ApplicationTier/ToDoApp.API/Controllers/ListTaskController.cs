using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.ListTask;

namespace ToDoApp.API.Controllers
{
    [Route("api/listTask")]
    [ApiController]
    public class ListTaskController : Controller
    {
        private readonly IListTaskService _listTaskService;
        public ListTaskController(IListTaskService listTaskService)
        {
            _listTaskService = listTaskService;
        }

        #region CRUD

        [HttpGet]
        [ProducesResponseType(typeof(IList<ListTaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _listTaskService.GetAll());
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] ListTaskRequest listTask)
        {
            await _listTaskService.Update(listTask);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ListTaskResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _listTaskService.GetOne(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] ListTaskRequest listTask)
        {
            await _listTaskService.Add(listTask);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _listTaskService.Delete(id);
            return Ok();
        }

        #endregion
    }
}
