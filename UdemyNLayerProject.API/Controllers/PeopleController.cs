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
    public class PeopleController : ControllerBase
    {
        private readonly IService<Person> _service;
        private readonly IMapper _mapper;

        public PeopleController(IService<Person> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
                
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var people = await _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(people));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var person = await _service.GetById(id);
            return Ok(_mapper.Map<PersonDto>(person));
        }

        [HttpPost]

        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var newPerson = await _service.Add(_mapper.Map<Person>(personDto));
            return Created(string.Empty,_mapper.Map<PersonDto>(newPerson));
        }

        [HttpDelete("{id}")]

        public IActionResult Remove(int id)
        {
            var deletePerson = _service.GetById(id).Result;
            _service.Remove(deletePerson);
            return NoContent();
        }

        [HttpPut]

        public IActionResult Update(PersonDto personDto)
        {
            _service.Update(_mapper.Map<Person>(personDto));
            return NoContent(); 
        }





    }
}
