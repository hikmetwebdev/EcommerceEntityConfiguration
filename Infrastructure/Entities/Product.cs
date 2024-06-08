using System.ComponentModel.DataAnnotations;
using Infrastructure.Commons;

namespace Infrastructure.Entities
{
    public class Product : BaseEntities<int>
    {
        public string Name { get; set; }
        public string? Details { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        private int _rating { get; set; }


        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public int Rating
        {
            get => _rating;
            set
            {
                if (value < 0 || value > 5)
                    throw new ArgumentOutOfRangeException(nameof(Rating), "Rating must be between 0 and 5");

                _rating = value;
            }
        }
    }
}
