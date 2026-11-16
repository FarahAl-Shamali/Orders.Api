using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Infrastructure.Services.Users;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAll(string searchKey)
        {
            var users = _userService.GetAll(searchKey);
            return Ok(GetResponse(users));
        }
        [HttpGet]
        public IActionResult Get(string Id)
        {
            var user = _userService.Get(Id);
            return Ok(GetResponse(user));
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateUserDto dto)
        {
            var savedId = _userService.Create(dto);
            return Ok(GetResponse(savedId));
        }
        [HttpPut]
        public IActionResult Update(UpdateUserDto dto)
        {
            var savedId = _userService.Update(dto);
            return Ok(GetResponse(savedId));
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var deletedId = _userService.Delete(id);
            return Ok(GetResponse(deletedId));
        }

    }
}
