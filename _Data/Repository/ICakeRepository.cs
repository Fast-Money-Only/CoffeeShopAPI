using Model;

namespace _Data.Repository;

public interface ICakeRepository
{
    IList<Cake> GetCakes();
    Cake CreateCake(Cake cake);
    void DeleteCake(Guid id);
}