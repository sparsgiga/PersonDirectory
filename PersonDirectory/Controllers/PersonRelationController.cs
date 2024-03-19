using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.PersonRelation.Command.Create;
using PersonDirectory.Application.PersonRelation.Command.Delete;

namespace PersonDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonRelationController(IMediator _mediator) : ControllerBase
    {
        /// <summary>
        /// Creates new relation of person
        /// </summary>
        /// <param name="request.name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(CreatePersonRelation))]
        public async Task<int> CreatePersonRelation([FromBody] CreatePersonRelationModelRequest request, CancellationToken cancellationToken) =>
            await _mediator.Send(request.Adapt<CreatePersonRelationCommand>(), cancellationToken);

        /// <summary>
        /// Deletes person relation by personId and relationId
        /// </summary>
        /// <param name="request.Id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(nameof(DeletePerson))]
        public async Task DeletePerson([FromBody] DeletePersonRelationModelRequest request) =>
            await _mediator.Send(request.Adapt<DeletePersonRelationCommand>());
    }
}
