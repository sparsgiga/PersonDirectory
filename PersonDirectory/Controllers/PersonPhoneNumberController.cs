using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.PersonPhoneNumber.Command.Create;
using PersonDirectory.Application.PersonPhoneNumber.Command.Delete;
using PersonDirectory.Application.PersonPhoneNumber.Command.Update;

namespace PersonDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneNumberController(IMediator _mediator) : ControllerBase
    {
        /// <summary>
        /// Creates new phone number for person
        /// </summary>
        /// <param name="request.name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(CreatePersonPhoneNumber))]
        public async Task<Unit> CreatePersonPhoneNumber([FromBody] CreatePersonPhoneNumberModelRequest request, CancellationToken cancellationToken) =>
            await _mediator.Send(request.Adapt<CreatePersonPhoneNumberCommand>(), cancellationToken);

        /// <summary>
        /// Deletes phonenumber by personId nad phoneNumberId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(nameof(DeletePersonPhoneNumber))]
        public async Task DeletePersonPhoneNumber([FromBody] DeletePersonPhoneNumberModelRequest request) =>
            await _mediator.Send(request.Adapt<DeletePersonPhoneNumberCommand>());

        /// <summary>
        /// Updates person phone number
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(nameof(UpdatePersonPhoneNumber))]
        public async Task UpdatePersonPhoneNumber([FromBody] UpdatePersonPhoneNumberModelRequest request) =>
            await _mediator.Send(request.Adapt<UpdatePersonPhoneNumberCommand>());
    }
}
