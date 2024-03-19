using MediatR;

namespace PersonDirectory.Application.Person.Queries.GetPersonRelationReport
{
    public class GetPersonRelationReportQuery : IRequest<List<PersonRelationReportModelResponse>>
    {
    }
}
