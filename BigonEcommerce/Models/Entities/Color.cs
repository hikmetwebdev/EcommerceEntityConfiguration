namespace BigonEcommerce.Models.Entities
{
    public class Color:BaseEntities<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }

    }
}
