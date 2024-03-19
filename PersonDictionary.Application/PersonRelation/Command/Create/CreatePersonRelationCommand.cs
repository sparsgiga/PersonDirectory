using MediatR;

namespace PersonDirectory.Application.PersonRelation.Command.Create
{
    public class CreatePersonRelationCommand : IRequest<int>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public int PersonRelationTypeId { get; set; }
    }
}
