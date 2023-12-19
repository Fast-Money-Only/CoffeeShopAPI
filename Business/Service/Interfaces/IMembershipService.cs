using _Data.Repository;
using Model;
namespace Business.Service.Interfaces;

public interface IMembershipService
{
    Membership? GetMemberhip(Guid id);
    Membership CreateMembership(Membership membership);
}