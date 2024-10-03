using BookStoreApi.Models;
using BookStoreApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;

        }


        //User Login
        [HttpPost]
        [Route("Userauth")]
        public ActionResult<string> UserLogin(UserDTO userDTO)
        {

            var user = new User
            {

                UserName = userDTO.UserName,
                Password = userDTO.Password,

            };

            var token = _userRepository.AuthenticateUser(user.UserName, user.Password);
            if (token == null)
            {
                return NotFound();
            }

            return Ok(token);

        }


        //Admin Login
        [HttpPost]
        [Route("Adminauth")]
        public ActionResult<string> AdminLogin(UserDTO userDTO)
        {

            var user = new User
            {

                UserName = userDTO.UserName,
                Password = userDTO.Password,

            };

            var token = _userRepository.AuthenticateAdmin(user.UserName, user.Password);
            if (token == null)
            {
                return NotFound();
            }

            return Ok(token);

        }




    }
}
