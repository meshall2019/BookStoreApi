using AutoMapper;

namespace BookStoreApi.Models
{
    public class profile : Profile
    {


        public profile()
        {
            CreateMap<Dto, Catagory>();
            CreateMap<Catagory, Dto>();
            CreateMap<Dto, Auther>();
            CreateMap<Auther, Dto>();

            CreateMap<DtoUpdate, Catagory>();
            CreateMap<Catagory, DtoUpdate>();
            CreateMap<DtoUpdate, Auther>();
            CreateMap<Auther, DtoUpdate>();

            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();



        }




    }
}
