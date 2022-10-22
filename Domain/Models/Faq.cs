using Domain.Common;

namespace Domain.Models
{
    public class Faq : ExtendedBaseModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
