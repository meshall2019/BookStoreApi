using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{

    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Title { get; set; }


        public string? BookImage { get; set; }

        public string? Description { get; set; }
        public DateTime AutherdDate { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.Now;




        public int CatagoryId { get; set; }
        public Catagory Category { get; set; }
        public int AutherId { get; set; }
        public Auther Auther { get; set; }



    }
}
