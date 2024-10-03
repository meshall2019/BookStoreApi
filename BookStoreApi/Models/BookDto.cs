using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models
{
    public class BookDto
    {


        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Title { get; set; }


        public IFormFile? BookImage { get; set; }

        public string? Description { get; set; }
        public DateTime AutherdDate { get; set; }





        public int CatagoryId { get; set; }
        public List<Dto> Category { get; set; }
        public int AutherId { get; set; }
        public List<Dto> Auther { get; set; }





    }
}
