using Business.Service.Interfaces;
using Model;

namespace _Data.Repository;

public class PostService : IPostService
{
    private IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public IList<Post> GetPosts()
    {
        return _postRepository.GetPosts();
    }

    public Post GetPost(Guid id)
    {
        return _postRepository.GetPost(id);
    }

    public Post AddPost(Post post)
    {
        return _postRepository.AddPost(post);
    }

    public void DeletePost(Guid id)
    {
        _postRepository.DeletePost(id);
    }

    public User GetUserFromPost(Guid id)
    {
        return _postRepository.getUserFromPost(id);
    }
}