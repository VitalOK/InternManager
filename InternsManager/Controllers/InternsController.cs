using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Controller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft;

namespace InternsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InternsController : ControllerBase
    {
        private static ICollection<Intern> _interns = new List<Intern>
        {
            //"Abdulaev Ramil", "Botnari Iulia", "Ciudacov Andrei", "Volosenco Maxim", "Miaun Alexandru", "Triboi Madalin"
            new Intern{Id = 1, FirstName = "Ramil", LastName = "Abdulaev", DateOfBirth = new DateTime(1989, 12, 17), Email = "Ramil.Abdulaev@stefanini.com", Description = "Experienced user" },
            new Intern{Id = 2, FirstName = "Iulia", LastName = "Botnari", DateOfBirth = new DateTime(1995, 7, 7), Email = "Iulia.Botnari@stefanini.com", Description = "Master degree" },
            new Intern{Id = 3, FirstName = "Madalin", LastName = "Triboi", DateOfBirth = new DateTime(1999, 2, 23), Email = "Madalin.Triboi@stefanini.com", Description = "Fresh graduated UTM" },
            new Intern{Id = 4, FirstName = "Andrei", LastName = "Ciudacov", DateOfBirth = new DateTime(1998, 10, 4), Email = "Andrei.Ciudacov@stefanini.com" }
        };


        [HttpGet]
        public IEnumerable<Intern> Get()
        {
            return _interns;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Intern intern)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_interns.Any(x => x.Id == intern.Id))
                return BadRequest($"The Id {intern.Id} is already in use!");

            _interns.Add(intern);

            return Ok();
        }

        [HttpPut]
        public void Put(int id, Intern intern)
        {
            var internToUpdate = _interns.SingleOrDefault(x => x.Id == id);
            if(internToUpdate != null)
            {
                _interns.Remove(internToUpdate);

                internToUpdate.Email = intern.Email;
                internToUpdate.Description = intern.Description;

                _interns.Add(internToUpdate);
                _interns.OrderBy(x => x.Id);
            }

        }


        //[AcceptVerbs("GET", "POST")]
        //public IActionResult VerifyId(int id)
        //{
        //    if (_interns.Any(x => x.Id == id))
        //    {
        //        return Json($"Id {id} is already in use.");
        //    }

        //    return Json(true);
        //}
    }
}
