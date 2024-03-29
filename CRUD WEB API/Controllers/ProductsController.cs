﻿using Shop_Management_WEB_API.Data;
using Shop_Management_WEB_API.DTOs.Inventory;
using Shop_Management_WEB_API.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Shop_Management_WEB_API.DTOs.Users;




namespace Shop_Management_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopWebApiContext _context;
        private readonly IMapper _mapper;


        public ProductsController(ShopWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                var productDtos = _mapper.Map<List<ProductDto>>(products);
                return productDtos;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet("{ProductId}")]
   
        public async Task<ActionResult<ProductDto>> GetProduct(int ProductId)
        {
            try
            {
                var product = await _context.Products.FindAsync(ProductId);

                if (product == null)
                {
                    var errorResponse = new
                    {
                        statusCode = 404,
                        remarks = "Product not found",
                        data = new
                        {
                            productId = ProductId
                        },
                        errors = ""
                    };

                    return NotFound(errorResponse);
                }

                var response = new
                {
                    statusCode = 200,
                    remarks = "Success",
                    data = new
                    {
                        productId = product.ProductId,
                        productName = product.ProductName,
                        productDescription = product.ProductDescription,
                        price = product.Price,
                        quantity = product.Quantity
                    },
                    errors = ""
                };

                return Ok(response);
            }catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }



        [HttpDelete("{ProductId}")]
        public async Task<ActionResult<ProductDto>> DeleteProduct(int ProductId)
        {
            try
            {
                var product =await  _context.Products.FindAsync(ProductId);
                if (product == null)
                {

                    var ErrorResponse = new
                    {
                        StatusCode = 404,
                        Remarks = "Product Not Found",
                        Data = new
                        {
                            ProductId = ProductId,
                        },
                        Errors = ""
                    };
                    return NotFound(ErrorResponse);

                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                var response = new
                {
                    StatusCode = 200,
                    Remarks = $"ProductId {ProductId} deleted successfully",
                    Data = new
                    {
                        ProductId = ProductId,
                        productName = product.ProductName,
                        productDescription = product.ProductDescription,
                        price = product.Price,
                        quantity = product.Quantity

                    }

                };
                return Ok(response);
            } catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProducts(ProductDto productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    Price = productDto.Price,
                    Quantity = productDto.Quantity,
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                var response = new
                {
                    StatusCode = 200,
                    Remarks = "Product added successfully",
                    Data = productDto,
                    Errors = "",
                };

                return Ok(response);
            } catch (Exception ex)
            {
                var errorResponse = new
                {
                    StatusCode = 500,
                    Remarks = "Internal Server Error",
                    Data = new
                    {
                        ProductName = "",
                        ProductDescription = "",
                        Price = "",
                        Quantity = "",
                    },
                    Errors = ex.Message
                };

               return StatusCode(500, errorResponse);
            }
            }
        }
     
    }

