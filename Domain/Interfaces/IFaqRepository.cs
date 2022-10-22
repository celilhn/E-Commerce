using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface IFaqRepository
    {
        Faq AddFaq(Faq faq);
        Faq UpdateFaq(Faq faq);
        Faq GetFaq(int Id);
        List<Faq> GetFags();
        List<Faq> GetFags(StatusCodes status);
    }
}
