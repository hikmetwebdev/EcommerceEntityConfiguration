using Infrastructure.Commons.Concrets;

namespace Infrastructure.Entities
{
    public class Color : BaseEntities<int>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

    }
}
