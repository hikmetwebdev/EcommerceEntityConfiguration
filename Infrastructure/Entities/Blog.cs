using Infrastructure.Commons.Concrets;

namespace Infrastructure.Entities
{
    public class Blog : BaseEntities<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public int BlogCategoryId { get; set; }
        public virtual BlogCategory? BlogCategory { get; set; }

    }
}
