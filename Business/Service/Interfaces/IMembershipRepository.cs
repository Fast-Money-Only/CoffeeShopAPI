using Model;
namespace _Data.Repository;

public interface IMembershipRepository
{
    Membership GetMemberhip(Guid id);
}