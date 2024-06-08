namespace Infrastructure.Commons.Concrets
{
    public abstract class BaseEntities<TKey> : AuditibleEntity
        where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
