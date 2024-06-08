using Infrastructure.Commons;

namespace Infrastructure.Entities
{
    public class Size : BaseEntities<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
