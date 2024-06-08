using Infrastructure.Commons.Abstracts;

namespace Infrastructure.Commons.Concrets
{
    public abstract class AuditibleEntity : IAuditibleEntity
    {
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
