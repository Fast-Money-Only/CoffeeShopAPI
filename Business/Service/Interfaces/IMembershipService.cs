using Model;
namespace Business.Service.Interfaces;

public interface IMembershipService
{
    Membership? GetMemberhip(Guid id);
}