using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.Models.Attackment;

namespace ToDoApp.API.Controllers
{
    [Route("api/attackment")]
    [ApiController]
    public class AttackmentController : ControllerBase
    {
        private readonly IAttackmentService _attackmentService;
        public AttackmentController(IAttackmentService attackmentService)
        {
            _attackmentService = attackmentService;
        }

        #region CRUD

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add([FromBody] AttackmentRequest assignment)
        {
            await _attackmentService.Add(assignment);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _attackmentService.Delete(id);
            return Ok();
        }

        [HttpGet("~/api/task/{taskId:int}/attackments")]
        [ProducesResponseType(typeof(IList<AttackmentResponse>), (int)HttpStatusCode.OK)]
        public async Task<IList<AttackmentResponse>> GetAttackmentsByTaskId([FromRoute] int taskId)
        {
            return await _attackmentService.GetAttackmentsByTaskId(taskId);
        }

        #endregion
    }
}
