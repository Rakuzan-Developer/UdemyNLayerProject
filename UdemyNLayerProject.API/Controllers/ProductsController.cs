using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Service.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [ServiceFilter(typeof(NotFoundFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("{id}/category")]

        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryById(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        
        [HttpPost]

        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct = await _productService.Add(_mapper.Map<Product>(productDto));
            return Created(string.Empty, newProduct);
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var updatedProduct = _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Remove(int id)
        {
            var deleteProduct = _productService.GetById(id).Result;
            _productService.Remove(deleteProduct);
            return NoContent();
        }

        

    }
}
