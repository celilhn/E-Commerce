using Domain.Common;

namespace Domain.Models
{
    public class Slider : ExtendedBaseModel
    {
        public string ImageUrl { get; set; }
        public string Text { get; set; }
        public string Href { get; set; }
        public string ButtonText { get; set; }
        public string ButtonColor { get; set; }
    }
}
