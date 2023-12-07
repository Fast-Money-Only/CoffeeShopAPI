using AutoMapper;
using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;
    
    public PostController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [Route("GetPosts")]
    public IActionResult GetPosts()
    {
        var posts = _postService.GetPosts();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public IActionResult GetPost(Guid id)
    {
        var post = _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] CreatePostDTO createPostDto)
    {
        try
        {
            var post = new Post();
            _mapper.Map(createPostDto, post);
            var newPost = _postService.AddPost(post);
            return CreatedAtAction(nameof(GetPost), new { id = newPost.Id }, newPost);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePost(Guid id)
    {
        try
        {
            _postService.DeletePost(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
}