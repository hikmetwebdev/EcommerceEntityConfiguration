using BigonEcommerce.Models.Entities.Common;

namespace BigonEcommerce.Models.Entities
{
    public class Color:BaseEntities<int>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

    }
}
