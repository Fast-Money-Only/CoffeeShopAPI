using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class User
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Password { get; set; }
    [Column(TypeName = "uniqueidentifier")]
    public Guid MembershipId { get; set; }
}