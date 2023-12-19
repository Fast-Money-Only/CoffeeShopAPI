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

    public Membership CreateMembership(Membership membership)
    {
        _context.Memberships.Add(membership);
        _context.SaveChanges();
        return membership;
    }
}