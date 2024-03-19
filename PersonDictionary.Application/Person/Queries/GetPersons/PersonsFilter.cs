using PersonDirectory.Domain.Enum;

namespace PersonDirectory.Application.Person.Queries.GetPersons
{
    public static class PersonsFilter
    {
        public static IQueryable<Domain.Aggregates.Person.Person> Filter(IQueryable<Domain.Aggregates.Person.Person> query, GetPersonsQuery filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.FilterQuery))
                query = query.Where(x => x.Name.ToLower().Contains(filter.FilterQuery.ToLower()) ||
                                         x.LastName.ToLower().Contains(filter.FilterQuery.ToLower()) ||
                                         x.PersonalNumber.Contains(filter.FilterQuery));


            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.LastName))
                query = query.Where(x => x.LastName.ToLower().Contains(filter.LastName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.PersonalNumber))
                query = query.Where(x => x.PersonalNumber.Contains(filter.PersonalNumber));

            if (filter.CityId > 0)
                query = query.Where(x => x.CityId == filter.CityId);

            if (Enum.IsDefined(typeof(GenderEnum), filter.Gender))
                query = query.Where(x => x.Gender == filter.Gender);

            if (filter.BirthDate != default(DateTime))
                query = query.Where(x => x.BirthDate.Date == filter.BirthDate.Date);

            return query;
        }
    }
}

