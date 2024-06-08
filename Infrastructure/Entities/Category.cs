using Infrastructure.Commons.Concrets;

namespace Infrastructure.Entities
{
    public class Category : BaseEntities<int>
    {
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        //public Category? ParentCategory { get; set; }
    }
}
