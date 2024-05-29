namespace BigonEcommerce.Models.Entities.Common
{
    public abstract class BaseEntities<TKey> : AuditibleEntity
        where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
