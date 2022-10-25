using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface ISliderRepository
    {
        Slider AddSlider(Slider slider);
        Slider UpdateSlider(Slider slider);
        Slider GetSlider(int id);
        List<Slider> GetSliders();
        List<Slider> GetSliders(StatusCodes statusCodes);
    }
}
