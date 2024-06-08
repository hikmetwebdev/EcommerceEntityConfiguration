namespace Infrastructure.Commons.Abstracts
{
    public interface IAuditibleEntity
    {
        int CreatedBy { get; set; }
        int? ModifiedBy { get; set; }
        int? DeletedBy { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
