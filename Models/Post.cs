using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Post
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Img { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}