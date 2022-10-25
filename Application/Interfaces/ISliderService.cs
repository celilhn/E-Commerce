using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface ISliderService
    {
        Slider AddSlider(Slider slider);
        Slider UpdateSlider(Slider slider);
        Slider GetSlider(int id);
        List<Slider> GetSliders();
        List<Slider> GetSliders(StatusCodes statusCodes);
    }
}
