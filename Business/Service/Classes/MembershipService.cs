using Business.Service.Interfaces;
using Model;

namespace _Data.Repository;

public class MembershipService : IMembershipService
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