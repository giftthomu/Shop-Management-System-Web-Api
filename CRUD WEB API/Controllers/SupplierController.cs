using AutoMapper;
using CRUD_WEB_API.DTOs.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Management_WEB_API.Common;
using Shop_Management_WEB_API.Data;

namespace CRUD_WEB_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
       private readonly ShopWebApiContext _context;
        private readonly IMapper _mapper;

        public SupplierController(ShopWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAllSuppliers() {

            try
            {
                var suppliers = await _context.Suppliers.ToListAsync();
                var suppliersDto = _mapper.Map<List<SupplierDto>>(suppliers);
                return suppliersDto;
            } catch (Exception ex)
            {
               
                return StatusCode(500, ex.Message);
            }
        }
    }
}
