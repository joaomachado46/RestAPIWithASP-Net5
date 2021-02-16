using Microsoft.AspNetCore.Mvc;
using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.person.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIWithASP_Net5.Controllers
{
    //PARA FAZER UM VERSIONAMENTO DA API TEM QUE SE INSTALAR O NUGET="microsoft.aspnetcore.mvc.versioning" E NO CONFIGURE SERVICES DO STARTUP, ADICIONAR O servicer.AddApiVersioning();

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            var person = _personBusiness.FindById(id);
            if (person == null)
                return NotFound();
            else
                return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personBusiness.Create(person));
        }

        // PUT api/<PersonController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personBusiness.Update(person));
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();

        }
    }
}
