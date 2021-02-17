using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPIWithASP_Net5.book.Business;
using RestAPIWithASP_Net5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiversion}")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Book> books = new List<Book>(await _bookBusiness.FindAllAsync());
                if (books != null)
                {
                    return Ok(books);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(_bookBusiness.FindById(id));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post(Book book)
        {
            try
            {
                if (book != null)
                {
                    return Ok(_bookBusiness.Create(book));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(Book book)
        {
            try
            {
                if (book != null)
                {
                    return Ok(_bookBusiness.Update(book));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
