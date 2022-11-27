using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class SliderService: ISliderService
    {
        private readonly ISliderRepository sliderRepository;
        public SliderService(ISliderRepository sliderRepository)
        {
            this.sliderRepository = sliderRepository;
        }

        public Slider AddSlider(Slider slider)
        {
            return sliderRepository.AddSlider(slider);
        }

        public Slider UpdateSlider(Slider slider)
        {
            return sliderRepository.UpdateSlider(slider);
        }

        public Slider GetSlider(int id)
        {
            return sliderRepository.GetSlider(id);
        }

        public List<Slider> GetSliders()
        {
            return sliderRepository.GetSliders();
        }

        public List<Slider> GetSliders(Constants.StatusCodes statusCodes)
        {
            return sliderRepository.GetSliders(statusCodes);
        }
    }
}
