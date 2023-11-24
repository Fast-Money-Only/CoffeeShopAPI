using Model;

namespace _Data.Repository;

public class MembershipService : IMembershipRepository
{
    private IMembershipRepository _membershipRepository;

    public MembershipService(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public Membership GetMemberhip(Guid id)
    {
        return _membershipRepository.GetMemberhip(id);
    }
}