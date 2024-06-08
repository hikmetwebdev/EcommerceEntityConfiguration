using Infrastructure.Commons;

namespace Infrastructure.Entities
{
    public class Color : BaseEntities<int>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

    }
}
