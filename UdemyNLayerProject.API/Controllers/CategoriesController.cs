using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpGet("{id}/products")]

        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsById(id);

            return Ok(_mapper.Map<CategoryWithProductsDto>(category));
        }

        [HttpPost]

        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var newCategory = await _categoryService.Add(_mapper.Map<Category>(categoryDto));

            return Created(string.Empty,_mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]

        public IActionResult Update(CategoryDto categoryDto)
        {
            var updatedCategory = _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Remove(int id)
        {
            var deleteCategory = _categoryService.GetById(id).Result;
            _categoryService.Remove(deleteCategory);

            return NoContent();
        }
    }
}
