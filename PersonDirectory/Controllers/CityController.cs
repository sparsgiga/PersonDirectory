using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.City.Commands.Create;
using PersonDirectory.Application.City.Commands.Delete;
using PersonDirectory.Application.City.Commands.Update;
using PersonDirectory.Application.City.Queries.Get;
using PersonDirectory.Common.Application.Paging;

namespace PersonDirectory.API.Controllers
{
    /// <summary>
    /// Controller for Cities
    /// </summary>
    /// <param name="_mediator"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(IMediator _mediator) : ControllerBase
    {
        /// <summary>
        /// Creates new city
        /// </summary>
        /// <param name="request.name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(CreateCity))]
        public async Task<int> CreateCity([FromBody] CreateCityModelRequest request, CancellationToken cancellationToken) =>
            await _mediator.Send(request.Adapt<CreateCityCommand>(), cancellationToken);

        /// <summary>
        /// Get all Cities with filter
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(nameof(GetCities))]
        public async Task<PagedResult<CityModelResponse>> GetCities([FromQuery] CityModelRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request.Adapt<GetCitiesQuery>(), cancellationToken);

        /// <summary>
        /// Updates City with name by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(nameof(UpdateCity))]
        public async Task UpdateCity([FromBody] UpdateCityModelRequest request) =>
            await _mediator.Send(request.Adapt<UpdateCityCommand>());

        /// <summary>
        /// Deletes city by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(nameof(DeleteCity))]
        public async Task DeleteCity([FromBody] DeleteCityModelRequest request) =>
            await _mediator.Send(request.Adapt<DeleteCityCommand>());
    }
}
