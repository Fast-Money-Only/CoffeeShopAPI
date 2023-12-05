namespace Model;

public class CreateUserDTO
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Password { get; set; }
    public Guid MembershipId { get; set; }
}