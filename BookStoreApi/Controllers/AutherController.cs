using AutoMapper;
using BookStoreApi.Models;
using BookStoreApi.Models.Repositories;
using BookStoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("[controller]")]
    //[ApiController]


    public class AutherController : ControllerBase
    {

        private readonly IAuthersRepository _autherRepository;
        private readonly IMapper _mapper;
        public BooksStoreDbContext2 _booksDbContext { get; set; }

        public AutherController(IAuthersRepository authersRepository, IMapper mapper, BooksStoreDbContext2 booksDbContext)
        {
            _autherRepository = authersRepository;
            _mapper = mapper;
            _booksDbContext = booksDbContext;
        }


        [HttpGet("AllAuthers")]
        public async Task<ActionResult<IEnumerable<Auther>>> GetAllAuthers()
        {
            var Authers = await _autherRepository.GetAuthersAsync();

            if (Authers == null)
                return NotFound();
            return Ok(Authers);

        }

        [HttpGet("GetAutherById")]
        public async Task<ActionResult<Auther>> GetCategoryById(int AutherById)
        {

            var Auther = await _autherRepository.GetAutherByIdAsync(AutherById);

            if (Auther == null)

                return NotFound();

            return Ok(_mapper.Map<Dto>(Auther));
        }

        //Add New Auther
        [HttpPost("AddNewAuther")]
        public async Task<ActionResult> AddNewAuther(Dto auther)
        {

            if (auther == null)
                return NotFound();

            await _autherRepository.AddAutherAsync(_mapper.Map<Auther>(auther));

            return Ok(auther);

        }


        [HttpDelete("RemoveAuther/{AutherId}")]

        public async Task<ActionResult> RemoveCategory(int AutherId)
        {
            var DeleteAuther = await _autherRepository.GetAutherByIdAsync(AutherId);

            _autherRepository.RemoveAuther(DeleteAuther);

            return Ok();

        }

        [HttpPut("UpdateAuther/{AutherId}")]
        public async Task<ActionResult> UpdateAutherAsync(int AutherId, DtoUpdate Auther)
        {
            var AutherEntity = await _autherRepository.GetAutherByIdAsync(AutherId);

            if (AutherEntity == null)
                return NotFound();

            _mapper.Map(Auther, AutherEntity);
            _booksDbContext.SaveChanges();

            return NoContent();
        }


    }
}
