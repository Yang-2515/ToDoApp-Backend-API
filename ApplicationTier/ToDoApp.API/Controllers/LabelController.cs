using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces.Services;
using Task = System.Threading.Tasks.Task;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoApp.Domain.Models.Label;
using AutoMapper.Internal.Mappers;
using AutoMapper;

namespace ToDoApp.API.Controllers
{
    [Route("api/label")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelService _labelService;
        public LabelController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        #region CRUD

        [HttpGet]
        [ProducesResponseType(typeof(IList<Label>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _labelService.GetAll());
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] LabelRequest label)
        {
            await _labelService.Update(label);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Label), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _labelService.GetOne(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] LabelRequest label)
        {
            await _labelService.Add(label);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _labelService.Delete(id);
            return Ok();
        }
        [HttpGet("~/api/task/{taskId:int}/labels")]
        [ProducesResponseType(typeof(List<LabelResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLabelsByTaskIdAsync(int taskId)
        {
            return Ok(await _labelService.GetLabelsByTaskIdAsync(taskId));
        }

        #endregion
    }
}
