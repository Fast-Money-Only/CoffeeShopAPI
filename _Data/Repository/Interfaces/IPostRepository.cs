using Model;

namespace _Data.Repository;

public interface IPostRepository
{
    IList<Post> GetPosts();
    Post GetPost(Guid id);
    Post AddPost(Post post);
    void DeletePost(Guid id);
}