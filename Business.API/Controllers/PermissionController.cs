using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Request.API.Application.Commands;
using Request.API.Application.Queries.Permission;

namespace Request.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPermissionQueries _permissionQueries;

        public PermissionController(
            IMediator mediator,
            IPermissionQueries permissionQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _permissionQueries = permissionQueries ?? throw new ArgumentNullException(nameof(permissionQueries));
        }

        [Route("{permissionId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Permission), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetPermissionAsync(int permissionId)
        {
            var permission = await _permissionQueries.GetPermissionAsync(permissionId);
            return Ok(permission);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Permission>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetPermissionsAsync()
        {
            var permissions = await _permissionQueries.GetPermissionsAsync();
            return Ok(permissions);
        }

        [Route("types")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PermissionType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetPermissionTypesAsync()
        {
            var permissionTypes = await _permissionQueries.GetPermissionTypesAsync();
            return Ok(permissionTypes);
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePermissionAsync([FromBody]CreatePermissionCommand command)
        {
            var commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("delete/{permissionId:int}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeletePermissionAsync(int permissionId)
        {
            var command = new DeletePermissionCommand(permissionId);
            var commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
