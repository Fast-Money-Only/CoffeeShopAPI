using Model;

namespace _Data.Repository;

public class CakeService : ICakeRepository
{
    private ICakeRepository _cakeRepository;

    public CakeService(ICakeRepository cakeRepository)
    {
        _cakeRepository = cakeRepository;
    }

    public IList<Cake> GetCakes()
    {
        return _cakeRepository.GetCakes();
    }

    public Cake GetCake(Guid id)
    {
        return _cakeRepository.GetCake(id);
    }

    public Cake CreateCake(Cake cake)
    {
        return _cakeRepository.CreateCake(cake);
    }

    public void DeleteCake(Guid id)
    {
        _cakeRepository.DeleteCake(id);
    }
}