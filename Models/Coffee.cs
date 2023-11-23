using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Coffee
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }
    public string Name { get; set; }
    
}