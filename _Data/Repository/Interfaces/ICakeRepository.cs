using Model;

namespace _Data.Repository;

public interface ICakeRepository
{
    IList<Cake> GetCakes();
    Cake GetCake(Guid id);
    Cake CreateCake(Cake cake);
    void DeleteCake(Guid id);
}