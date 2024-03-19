using Mapster;
using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Application.Services;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.Person.Queries.GetPerson
{
    public class GetPersonQueryHandler(IUnitOfWork _uof, IFileManagerService _fileManager)
        : IRequestHandler<GetPersonQuery, GetPersonModelResponse>
    {
        public async Task<GetPersonModelResponse> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _uof.PersonRepository.GetAllDetailsByIdAsync(request.Id);

            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(Domain.Aggregates.Person.Person), request.Id));

            var response = person.Adapt<GetPersonModelResponse>();

            return response;
        }
    }
}
