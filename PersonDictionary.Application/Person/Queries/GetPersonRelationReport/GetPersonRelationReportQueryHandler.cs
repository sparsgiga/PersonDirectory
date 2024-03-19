using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.Person.Queries.GetPersonRelationReport
{
    public class GetPersonRelationReportQueryHandler(IUnitOfWork _uof) : IRequestHandler<GetPersonRelationReportQuery, List<PersonRelationReportModelResponse>>
    {
        public async Task<List<PersonRelationReportModelResponse>> Handle(GetPersonRelationReportQuery request, CancellationToken cancellationToken)
        {
            var allPersonRelations = _uof.PersonRelationRepository.GetAllRelationsAsync();

            return await _uof.PersonRelationRepository.GetAllRelationsAsync()
                            .GroupBy(pr => new
                            {
                                pName = pr.Person.Name,
                                pLastName = pr.Person.LastName,
                                pNumber = pr.Person.PersonalNumber,
                                prId = pr.PersonRelationType.Id,
                                prName = pr.PersonRelationType.Name
                            })
                            .Select(grouped => new PersonRelationReportModelResponse
                            {
                                Name = grouped.Key.pName,
                                LastName = grouped.Key.pLastName,
                                PersonalNumber = grouped.Key.pNumber,
                                PersonRelationType = grouped.Key.prName,
                                Quantity = grouped.Count()
                            }).ToListAsync(); ;
        }
    }
}
