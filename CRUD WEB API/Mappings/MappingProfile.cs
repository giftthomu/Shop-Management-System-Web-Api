using AutoMapper;
using Microsoft.Extensions.Logging;
using Shop_Management_WEB_API.DTOs.Inventory;
using Shop_Management_WEB_API.DTOs.Users;
using Shop_Management_WEB_API.Models.Inventory;
using Shop_Management_WEB_API.Models.Users;

namespace CRUD_WEB_API.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Users, UserDto>();
        }
    }
}
