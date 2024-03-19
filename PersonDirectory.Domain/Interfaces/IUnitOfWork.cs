using PersonDirectory.Domain.Aggregates.City;
using PersonDirectory.Domain.Aggregates.Person;
using PersonDirectory.Domain.Aggregates.Person.PersonRelation;
using PersonDirectory.Domain.Aggregates.PersonRelationType;
using PersonDirectory.Domain.Aggregates.PhoneNumberType;

namespace PersonDirectory.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        ICityRepository CityRepository { get; }
        IPersonRelationTypeRepository PersonRelationTypeRepository { get; }
        IPersonRelationRepository PersonRelationRepository { get; }
        IPhoneNumberTypeRepository PhoneNumberTypeRepository { get; }

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
