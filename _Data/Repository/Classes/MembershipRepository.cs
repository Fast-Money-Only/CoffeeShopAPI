using Model;

namespace _Data.Repository;

public class MembershipRepository : IMembershipRepository
{
    private readonly CoffeeShopContext _context;

    public MembershipRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public Membership GetMemberhip(Guid id)
    {
        return _context.Memberships.Find(id);
    }
}