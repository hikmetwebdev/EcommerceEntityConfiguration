using Infrastructure.Commons;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class Tag : BaseEntities<int>
    {
        [MaxLength(20)]
        public required string Name { get; set; }
    }
}
