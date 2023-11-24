using _Data.Repository;
using Business.Service.Interfaces;
using Model;

namespace Business.Service;

public class AddressService : IAddressService
{
    private IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public Address CreateAddress(Address address)
    {
        return _addressRepository.CreateAddress(address);
    }

    public Address GetAddress(Guid id)
    {
        return _addressRepository.GetAddress(id);
    }

    public Address UpdateAddress(Guid id, Address address)
    {
        return _addressRepository.UpdateAddress(id, address);
    }

    public void DeleteAddress(Guid id)
    {
        _addressRepository.DeleteAddress(id);
    }
}