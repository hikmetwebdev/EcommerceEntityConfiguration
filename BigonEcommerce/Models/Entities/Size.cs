using BigonEcommerce.Models.Entities.Common;

namespace BigonEcommerce.Models.Entities
{
    public class Size:BaseEntities<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
