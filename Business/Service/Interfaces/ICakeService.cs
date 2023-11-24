using Model;

namespace Business.Service.Interfaces;

public interface ICakeService
{
    IList<Cake> GetCakes();
    Cake? GetCake(Guid id);
    Cake CreateCake(Cake cake);
    void DeleteCake(Guid id);
}