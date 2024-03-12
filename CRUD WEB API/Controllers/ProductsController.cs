using CRUD_WEB_API.Data;
using CRUD_WEB_API.Models.Inventory;
using CRUD_WEB_API.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WEB_API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CrudWebApiContext _context;

        public ProductsController(CrudWebApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

       
    }
}
