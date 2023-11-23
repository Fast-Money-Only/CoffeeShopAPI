using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Membership
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }
    public string Title { get; set; }
    
    
}