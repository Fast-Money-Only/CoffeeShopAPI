using AutoMapper;
using Model;

namespace Presentation;

public class MappingProfile :  Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePostDTO, Post>();
        CreateMap<Post, CreatePostDTO>();
        CreateMap<CreateUserDTO, User>();
        CreateMap<User, CreateUserDTO>();
        CreateMap<CreateOrderDTO, Order>();
        CreateMap<Order, CreateOrderDTO>();
    }
}