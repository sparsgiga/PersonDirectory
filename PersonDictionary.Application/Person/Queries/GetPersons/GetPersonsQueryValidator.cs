using FluentValidation;

namespace PersonDirectory.Application.Person.Queries.GetPersons
{
    public class GetPersonsQueryValidator : AbstractValidator<GetPersonsQuery>
    {
        public GetPersonsQueryValidator()
        {
        }
    }
}
