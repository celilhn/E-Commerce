using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFaqRepository
    {
        Faq AddFaq(Faq faq);
        Faq UpdateFaq(Faq faq);
        Faq GetFaq(int Id);
        List<Faq> GetFags();
        List<Faq> GetFags(Constants.Constants.StatusCodes status);
    }
}
