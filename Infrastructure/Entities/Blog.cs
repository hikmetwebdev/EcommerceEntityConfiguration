using Infrastructure.Commons.Concrets;

namespace Infrastructure.Entities
{
    public class Blog : BaseEntities<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishdeAt { get; set; }
        public int PublishdeBy { get; set; }
        public int BlogCategoryId { get; set; }

    }
}
