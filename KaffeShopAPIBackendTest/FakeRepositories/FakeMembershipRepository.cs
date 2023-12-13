using _Data;
using _Data.Repository;
using Model;

namespace KaffeShopAPIBackendTest.FakeRepositories;

public class FakeMembershipRepository : IMembershipRepository
{
    private readonly CoffeeShopContext _context;

    public FakeMembershipRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public Membership GetMemberhip(Guid id)
    {
        return _context.Memberships.Find(id);
    }

    public Membership CreateMembership(Membership membership)
    {
        _context.Memberships.Add(membership);
        _context.SaveChanges();
        return membership;
    }
}