using _Data;
using _Data.Repository;
using Model;

namespace KaffeShopAPIBackendTest.FakeRepositories;

public class FakeAddressRepository : IAddressRepository
{
    private readonly CoffeeShopContext _context;

    public FakeAddressRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public Address CreateAddress(Address address)
    {
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return address;
    }

    public Address GetAddress(Guid id)
    {
        return _context.Addresses.Find(id);
    }

    public Address UpdateAddress(Guid id, Address address)
    {
        var addressToUpdate = GetAddress(id);
        addressToUpdate.StreetName = address.StreetName;
        addressToUpdate.HouseNumber = address.HouseNumber;
        addressToUpdate.CityName = address.CityName;
        addressToUpdate.PostNumber = address.PostNumber;

        _context.SaveChanges();
        return addressToUpdate;
    }

    public void DeleteAddress(Guid id)
    {
        _context.Addresses.Remove(GetAddress(id));
        _context.SaveChanges();
    }
}