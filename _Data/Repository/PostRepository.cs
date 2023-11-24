using Model;

namespace _Data.Repository;

public class PostRepository : IPostRepository
{
    private readonly CoffeeShopContext _context;

    public PostRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public IList<Post> GetPosts()
    {
        return _context.Posts.ToList();
    }

    public Post GetPost(Guid id)
    {
        return _context.Posts.Find(id);
    }

    public Post AddPost(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post;
    }

    public void DeletePost(Guid id)
    {
        _context.Posts.Remove(GetPost(id));
        _context.SaveChanges();
    }
}