using Microsoft.AspNetCore.Mvc;
using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.person.Business;
using System.Collections.Generic;

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
        //DATAANOTATIONS PARA FORMATAR O SWAGGER
        [ProducesResponseType((200), Type =  typeof(List<Person>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        //DATAANOTATIONS PARA FORMATAR O SWAGGER
        [ProducesResponseType((200), Type = typeof(Person))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Get(int id)
        {

            var person = _personBusiness.FindById(id);
            if (person == null)
                return NotFound();
            else
                return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        //DATAANOTATIONS PARA FORMATAR O SWAGGER
        [ProducesResponseType((200), Type = typeof(Person))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personBusiness.Create(person));
        }

        // PUT api/<PersonController>/5
        [HttpPut]
        //DATAANOTATIONS PARA FORMATAR O SWAGGER
        [ProducesResponseType((200), Type = typeof(Person))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personBusiness.Update(person));
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        //DATAANOTATIONS PARA FORMATAR O SWAGGER
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();

        }
    }
}
