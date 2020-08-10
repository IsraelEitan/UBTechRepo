using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using System.Web.Http;

using UBTeach.Data.Models;
using UBTeach.Service.Services;
using UBTech.Service.DTOS;

namespace UBTeachAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        
        [Route("GetPersonList/term")]
        [HttpGet]
        public async Task<ActionResult> GetPersonList(string term)
        {
            try
            {
               
               var clientList = (await _personService.Find(

               x => (term != null) && term.Contains(" ") ?
               (x.FirstName + ' ' + x.LastName).Contains(term) : x.FirstName.Contains(term))
               )
               .Select(
                    person => new PersonDTO
                    {
                        Id = person.Id,
                        FirstName = person.FirstName,
                        Age = person.Age,
                        LastName = person.LastName,
                        Role = person.Role
                    }).ToList();

                    return Ok(clientList);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
       
        }
        
    }
}