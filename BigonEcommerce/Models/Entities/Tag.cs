using BigonEcommerce.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace BigonEcommerce.Models.Entities
{
    public class Tag:BaseEntities<int>
    {
        [MaxLength(20)]
        public required string Name { get; set; }
    }
}
