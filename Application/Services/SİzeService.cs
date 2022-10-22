using System.Collections.Generic;
using Application.Interfaces;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class SİzeService : ISizeService
    {
        private readonly ISizeRepository sizeRepository;
        public SİzeService(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public Size AddSize(Size size)
        {
            return sizeRepository.AddSize(size);
        }

        public Size GetSize(int Id)
        {
            return sizeRepository.GetSize(Id);
        }

        public Size UpdateSize(Size size)
        {
            return sizeRepository.UpdateSize(size);
        }

        public List<Size> GetSizes()
        {
            return sizeRepository.GetSizes();
        }

        public List<Size> GetSizes(StatusCodes status)
        {
            return sizeRepository.GetSizes(status);
        }
    }
}
