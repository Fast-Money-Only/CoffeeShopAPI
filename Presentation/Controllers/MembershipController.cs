using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembershipController : Controller
{
    private readonly IMembershipService _membershipService;
    
    public MembershipController(IMembershipService membershipService)
    {
        _membershipService = membershipService;
    }
    
    [HttpGet]
    [Route("GetMembership")]
    public IActionResult GetMembership(Guid id)
    {
        var membership = _membershipService.GetMemberhip(id);
        return Ok(membership);
    }
}