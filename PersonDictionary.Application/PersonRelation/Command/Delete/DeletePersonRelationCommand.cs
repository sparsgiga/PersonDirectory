using MediatR;

namespace PersonDirectory.Application.PersonRelation.Command.Delete
{
    public class DeletePersonRelationCommand : IRequest<Unit>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public int PersonRelationTypeId { get; set; }
    }
}
