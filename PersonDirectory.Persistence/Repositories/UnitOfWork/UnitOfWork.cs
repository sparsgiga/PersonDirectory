using Microsoft.EntityFrameworkCore.Storage;
using PersonDirectory.Domain.Aggregates.City;
using PersonDirectory.Domain.Aggregates.Person;
using PersonDirectory.Domain.Aggregates.Person.PersonRelation;
using PersonDirectory.Domain.Aggregates.PersonRelationType;
using PersonDirectory.Domain.Aggregates.PhoneNumberType;
using PersonDirectory.Domain.Interfaces;
using PersonDirectory.Persistence.Context;

namespace PersonDirectory.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonDirectoryDbContext _context;

        private IDbContextTransaction _transaction;
        public ICityRepository CityRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public IPersonRelationTypeRepository PersonRelationTypeRepository { get; }
        public IPersonRelationRepository PersonRelationRepository { get; }
        public IPhoneNumberTypeRepository PhoneNumberTypeRepository { get; }

        public UnitOfWork(PersonDirectoryDbContext context, ICityRepository cityRepository, IPersonRepository personRepository,
                          IPersonRelationTypeRepository personRelationTypeRepository, IPersonRelationRepository personRelationRepository,
                          IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _context = context;
            CityRepository = cityRepository;
            PersonRepository = personRepository;
            PersonRelationTypeRepository = personRelationTypeRepository;
            PersonRelationRepository = personRelationRepository;
            PhoneNumberTypeRepository = phoneNumberTypeRepository;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null)
            {
                return;
            }

            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    Dispose();
                }
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
            _transaction = null;
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null)
            {
                return;
            }

            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
             => await _context.SaveChangesAsync(cancellationToken);
    }
}
