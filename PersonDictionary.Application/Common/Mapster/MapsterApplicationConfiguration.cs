using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PersonDirectory.Application.Person.Queries.GetPerson;
using PersonDirectory.Application.Person.Queries.GetPersons;

namespace PersonDirectory.Application.Common.Mapster
{
    public static class MapsterApplicationConfiguration
    {
        public static void RegisterMapsterApplicationConfiguration(this IServiceCollection services)
        {

            TypeAdapterConfig<Domain.Aggregates.Person.PersonRelation.PersonRelation, PersonRelationResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.RelatedPerson.Id)
                .Map(dest => dest.Name, src => src.RelatedPerson.Name)
                .Map(dest => dest.LastName, src => src.RelatedPerson.LastName)
                .Map(dest => dest.Gender, src => src.RelatedPerson.Gender)
                .Map(dest => dest.PersonalNumber, src => src.RelatedPerson.PersonalNumber)
                .Map(dest => dest.BirthDate, src => src.RelatedPerson.BirthDate);

            TypeAdapterConfig<Domain.Aggregates.Person.Person, GetPersonModelResponse>
                .NewConfig()
                .Map(dest => dest.PersonId, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.PersonalNumber, src => src.PersonalNumber)
                .Map(dest => dest.BirthDate, src => src.BirthDate)
                .Map(dest => dest.Photo, src => src.Photo)
                .Map(dest => dest.RelatedPersons, src => src.RelatedPersons);

            TypeAdapterConfig<Domain.Aggregates.Person.PersonPhoneNumber, PersonPhoneNumberResponse>
                .NewConfig()
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.PhoneNumberType, src => src.PhoneNumberType.Name);

            TypeAdapterConfig<Domain.Aggregates.Person.Person, GetPersonsModelResponse>
                .NewConfig()
                .Map(dest => dest.PersonId, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.BirthDate, src => src.BirthDate)
                .Map(dest => dest.PersonalNumber, src => src.PersonalNumber)
                .Map(dest => dest.Photo, src => src.Photo);
        }
    }
}
