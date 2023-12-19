using Model;

namespace Business.Service.Interfaces;

public interface IAddressService
{
    Address CreateAddress(Address address);
    Address? GetAddress(Guid id);
    Address UpdateAddress(Guid id, Address address);
    void DeleteAddress(Guid id);
}