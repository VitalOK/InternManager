using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace InternsManager.Controllers
{
    [ApiController]
    [Route("api/Interns")]
    public class InternsController : ControllerBase
    {
        private readonly IService<Intern> _internService;

        public InternsController(IService<Intern> internService)
        {
            _internService = internService;
        }


        [HttpGet]
        public IEnumerable<Intern> Get()
        {
            return _internService.GetAll();
        }

        [HttpGet("{id}")]
        public Intern Get(int id)
        {
            var output = _internService.GetById(id);
            return output;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Intern intern)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _internService.Insert(intern);

            //if (_interns.Any(x => x.Id == intern.Id))
            //    return BadRequest($"The Id {intern.Id} is already in use!");


            return Ok();
        }

        [HttpPut]
        public ActionResult Put(Intern intern)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _internService.Update(intern);

            return Ok();
        }
    }
}
