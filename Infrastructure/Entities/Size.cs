using Infrastructure.Commons.Concrets;

namespace Infrastructure.Entities
{
    public class Size : BaseEntities<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
