namespace PersonDirectory.Domain.Base
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; protected set; }

        public bool IsDeleted { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
