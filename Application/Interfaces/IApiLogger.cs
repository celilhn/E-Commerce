using Application.Models;

namespace Application.Interfaces
{
    public interface IApiLogger
    {
        void Log(LogDetail logDetail);
    }
}
