using AutoMapper;
using BookStoreApi.Models;
using BookStoreApi.Models.Repositories;
using BookStoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]


    public class BookController : ControllerBase
    {

        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        public BooksStoreDbContext2 _booksDbContext { get; set; }

        public BookController(IBooksRepository booksRepository, IMapper mapper, BooksStoreDbContext2 booksDbContext, IFileProvider fileProvider)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
            _booksDbContext = booksDbContext;
            _fileProvider = fileProvider;

        }


        [HttpGet("AllBooks")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var Books = await _booksRepository.GetBooksAsync();

            if (Books == null)
                return NotFound();
            return Ok(Books);

        }

        [HttpGet("GetBookById")]
        public async Task<ActionResult<Book>> GetBookById(int BookId)
        {

            var Book = await _booksRepository.GetBookByIdAsync(BookId);

            if (Book == null)

                return NotFound();

            return Ok(Book);
        }


        [HttpPost("AddNewBook")]
        public async Task<ActionResult> AddNewBook(BookDto book)
        {
            //using var stream = new MemoryStream();
            //await book.BookImage.CopyToAsync(stream);
            if (book == null)
                return NotFound();

            //var b = new Book
            //{
            //    Price= book.Price,
            //    Title= book.Title,
            //    BookImage=stream.ToArray(),
            //    Description=book.Description,
            //    CatagoryId = book.CatagoryId,
            //    AutherId = book.AutherId

            //};

            //var AddBook = _mapper.Map<Book>(book);
            //AddBook.BookImage = stream.ToArray();


            if (book.BookImage != null)
            {
                var root = "/images/BookImage/";
                var bookname = $"{Guid.NewGuid()}" + book.BookImage.FileName;
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                var src = root + bookname;
                var imagename = bookname;
                var pic_info = _fileProvider.GetFileInfo(src);
                var root_path = pic_info.PhysicalPath;
                using (var file_stream = new FileStream(root_path, FileMode.Create))
                {
                    await book.BookImage.CopyToAsync(file_stream);
                }
                //Create New Book
                var res = _mapper.Map<Book>(book);
                res.BookImage = "http://localhost:8081/" + imagename;

                await _booksRepository.AddbookAsync(res);

            }

            return Ok(book);



        }

        [HttpDelete("RemoveBook/{BookId}")]

        public async Task<ActionResult> RemoveBook(int BookId)
        {
            var DeleteAuther = await _booksRepository.GetBookByIdAsync(BookId);

            _booksRepository.RemoveBook(DeleteAuther);

            return Ok();

        }

        [HttpPut("UpdateBook/{BookId}")]
        public async Task<ActionResult> UpdateAutherAsync(int BookId, BookDto book)
        {
            var BookEntity = await _booksRepository.GetBookByIdAsync(BookId);

            if (BookEntity == null)
                return NotFound();

            _mapper.Map(book, BookEntity);
            _booksDbContext.SaveChanges();

            return NoContent();
        }


    }
}
