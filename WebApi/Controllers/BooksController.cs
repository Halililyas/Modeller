using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositoriys;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _repositoryContext;

       public  BooksController(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resutl = _repositoryContext.Books.ToList();
            return Ok(resutl);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name ="id")] int id)
        {
            try
            {
                var resutl = _repositoryContext
               .Books
               .Where(b => b.Id.Equals(id))
               .SingleOrDefault();
                if (resutl is null)
                    return NoContent();//404
                return Ok(resutl);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody]Book book)
        {
            if (book is null)
                return NoContent();//400

            try
            {
                var result = _repositoryContext.Books.Add(book);
                _repositoryContext.SaveChanges();
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name ="id")]int id, [FromBody]Book book)
        {
            //Chack book
            var entity = _repositoryContext
                .Books.Where(b => b.Id.Equals(id))
                .SingleOrDefault();
           
            
            if (entity is null)
                return NoContent();//404
            //Check İd 
            if (id != book.Id)
                return BadRequest();//400
            try
            {
                entity.Title = book.Title;
                entity.Price = book.Price;
                _repositoryContext.SaveChanges();
                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteIdBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entiy = _repositoryContext
               .Books
               .Where(b => b.Id.Equals(id))
               .SingleOrDefault();
                if (entiy is null)
                {

                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Book with id:{id} could not found"
                    });
                }
                _repositoryContext.Remove(entiy);
                _repositoryContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);



            }
        }
    }
}
