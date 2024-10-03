using AutoMapper;
using BookStoreApi.Models;
using BookStoreApi.Models.Repositories;
using BookStoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("[controller]")]
    //[ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;
        public BooksStoreDbContext2 _booksDbContext { get; set; }

        public CategoryController(ICategoriesRepository categoriesRepository, IMapper mapper, BooksStoreDbContext2 booksDbContext)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
            _booksDbContext = booksDbContext;
        }


        [HttpGet("AllCategories")]
        public async Task<ActionResult<IEnumerable<Catagory>>> GetAllCategories()
        {
            var x = await _categoriesRepository.GetCategoriesAsync();

            if (x == null)

                return NotFound();

            return Ok(x);

        }

        [HttpGet("GetCategoryById")]
        public async Task<ActionResult<IEnumerable<Catagory>>> GetCategoryById(int CategoryId)
        {

            var x = await _categoriesRepository.GetCategoryByIdAsync(CategoryId);

            if (x == null)

                return NotFound();

            return Ok(x);
        }


        [HttpPost("AddNewCategory")]
        public async Task<ActionResult> AddNewCategory(Dto catagory)
        {

            if (catagory == null)
                return NotFound();

            await _categoriesRepository.AddCategoryAsync(_mapper.Map<Catagory>(catagory));

            return Ok(catagory);

        }

        [HttpDelete("DeleteCategory/{CategoryId}")]

        public async Task<ActionResult> RemoveCategory(int CategoryId)
        {
            var DeleteCategory = await _categoriesRepository.GetCategoryByIdAsync(CategoryId);

            _categoriesRepository.RemoveCategory(DeleteCategory);

            return Ok();

        }

        [HttpPut("UpdateCategory/{CategoryId}")]
        public async Task<ActionResult> UpdateCategoryAsync(int CategoryId, Dto category)
        {
            var CategoryEntity = await _categoriesRepository.GetCategoryByIdAsync(CategoryId);

            if (CategoryEntity == null)
                return NotFound();

            _mapper.Map(category, CategoryEntity);
            _booksDbContext.SaveChanges();

            return NoContent();
        }



    }
}
