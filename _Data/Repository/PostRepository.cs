using Model;

namespace _Data.Repository;

public class PostRepository : IPostRepository
{
    public IList<Post> GetPosts()
    {
        throw new NotImplementedException();
    }

    public Post GetPost(Guid id)
    {
        throw new NotImplementedException();
    }

    public Post AddPost(Post post)
    {
        throw new NotImplementedException();
    }

    public void DeletePost(Guid id)
    {
        throw new NotImplementedException();
    }
}