using Model;

namespace Business.Service.Interfaces;

public interface IPostService
{
    IList<Post> GetPosts();
    Post? GetPost(Guid id);
    Post AddPost(Post post);
    void DeletePost(Guid id);
}