using PersonDirectory.Domain.Base;

namespace PersonDirectory.Domain.Aggregates.Person.PersonRelation
{
    public class PersonRelation(
        int personId,
        int relatedPersonId,
        int personRelationTypeId) : Entity<int>
    {
        public int PersonId { get; private set; } = personId;
        public int RelatedPersonId { get; private set; } = relatedPersonId;
        public int PersonRelationTypeId { get; private set; } = personRelationTypeId;


        public static PersonRelation Create(int personId, int relatedPersonId, int personRelationTypeId)
        {
            return new PersonRelation(personId, relatedPersonId, personRelationTypeId);
        }

        public virtual Person Person { get; private set; }
        public virtual Person RelatedPerson { get; private set; }
        public virtual PersonRelationType.PersonRelationType PersonRelationType { get; private set; }

    }
}
