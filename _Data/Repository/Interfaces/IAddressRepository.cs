using Model;

namespace _Data.Repository;

public interface IAddressRepository
{
    Address CreateAddress(Address address);
    Address GetAddress(Guid id);
    Address UpdateAddress(Guid id, Address address);
    void DeleteAddress(Guid id);
}