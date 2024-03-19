using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.Person.Commands.Create;
using PersonDirectory.Application.Person.Commands.Delete;
using PersonDirectory.Application.Person.Commands.DeletePhoto;
using PersonDirectory.Application.Person.Commands.Update;
using PersonDirectory.Application.Person.Commands.UploadPhoto;
using PersonDirectory.Application.Person.Queries.DownloadPersonImage;
using PersonDirectory.Application.Person.Queries.GetPerson;
using PersonDirectory.Application.Person.Queries.GetPersonRelationReport;
using PersonDirectory.Application.Person.Queries.GetPersons;
using PersonDirectory.Common.Application.Paging;


namespace PersonDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController(IMediator _mediator) : ControllerBase
    {
        /// <summary>
        /// Get person by Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(GetPersonById))]
        public async Task<GetPersonModelResponse> GetPersonById([FromQuery] GetPersonModelRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request.Adapt<GetPersonQuery>(), cancellationToken);

        /// <summary>
        /// Get all persons with filter
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(GetPersons))]
        public async Task<PagedResult<GetPersonsModelResponse>> GetPersons([FromQuery] GetPersonsModelRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request.Adapt<GetPersonsQuery>(), cancellationToken);


        /// <summary>
        /// Get persons report by relation type
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(GetPersonRelationReport))]
        public async Task<List<PersonRelationReportModelResponse>> GetPersonRelationReport(CancellationToken cancellationToken)
            => await _mediator.Send(new GetPersonRelationReportQuery(), cancellationToken);

        /// <summary>
        /// Download person's photo by url
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(nameof(DownloadPersonPhoto))]
        public async Task<IActionResult> DownloadPersonPhoto([FromQuery] DownloadPersonImageModelRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request.Adapt<DownloadPersonImageCommand>(), cancellationToken);
            return File(response, "image/jpeg");
        }

        /// <summary>
        /// Creates new Person
        /// </summary>
        /// <param name="request.name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(PostPerson))]
        public async Task<int> PostPerson([FromBody] CreatePersonModelRequest request, CancellationToken cancellationToken) =>
            await _mediator.Send(request.Adapt<CreatePersonCommand>(), cancellationToken);

        /// <summary>
        /// Updates Person by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(nameof(UpdatePerson))]
        public async Task UpdatePerson([FromBody] UpdatePersonModelRequest request) =>
            await _mediator.Send(request.Adapt<UpdatePersonCommand>());

        /// <summary>
        /// Deletes person by Id
        /// </summary>
        /// <param name="request.Id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(nameof(DeletePerson))]
        public async Task DeletePerson([FromBody] DeletePersonModelRequest request) =>
            await _mediator.Send(request.Adapt<DeletePersonCommand>());

        /// <summary>
        /// Upload person photo by personId with photo's file
        /// </summary>
        /// <param name="request"></param>
        /// <param name="request"></param>
        /// <returns></returns>        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost(nameof(UploadPersonPhoto))]
        public async Task<Unit> UploadPersonPhoto([FromForm] UploadPersonPhotoModelRequest request) =>
            await _mediator.Send(new UploadPersonPhotoCommand { PersonId = request.PersonId, Photo = request.Photo });

        /// <summary>
        /// Delete person's photo by personId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(nameof(DeletePersonPhoto))]
        public async Task DeletePersonPhoto([FromBody] DeletePersonPhotoModelRequest request) =>
            await _mediator.Send(request.Adapt<DeletePersonPhotoCommand>());
    }
}
