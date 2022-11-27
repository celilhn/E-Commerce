using System.Collections.Generic;
using System.Linq;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class SliderRepository : ISliderRepository
    {
        private readonly ECommerceDbContext context;
        public SliderRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public Slider AddSlider(Slider slider)
        {
            context.Sliders.Add(slider);
            context.SaveChanges();
            return slider;
        }

        public Slider UpdateSlider(Slider slider)
        {
            context.Entry(slider).State = EntityState.Modified;
            context.SaveChanges();
            return slider;
        }

        public Slider GetSlider(int id)
        {
            return context.Sliders.SingleOrDefault(x => x.Id == id);
        }

        public List<Slider> GetSliders()
        {
            return context.Sliders.Where(x=>x.Status != StatusCodes.Deleted).ToList();
        }

        public List<Slider> GetSliders(StatusCodes statusCodes)
        {
            return context.Sliders.Where(x => x.Status == statusCodes).ToList();
        }
    }
}
