namespace Model;

public class CreatePostDTO
{
   
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Img { get; set; }
    public int Like { get; set; }
    public Guid UserId { get; set; }
}