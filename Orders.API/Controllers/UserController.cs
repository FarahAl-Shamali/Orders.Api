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
        public async Task<ActionResult> GetAll(string searchKey)
        {
            var users = await _userService.GetAll(searchKey);
            return Ok(await GetResponse(users));
        }
        [HttpGet]
        public async Task<ActionResult> Get(string Id)
        {
            var user = await _userService.Get(Id);
            return Ok(await GetResponse(user));
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateUserDto dto)
        {
            var savedId = await _userService.Create(dto);
            return Ok(await GetResponse(savedId));
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateUserDto dto)
        {
            var savedId = await _userService.Update(dto);
            return Ok(await GetResponse(savedId));
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var deletedId =await _userService.Delete(id);
            return Ok(await GetResponse(deletedId));
        }

    }
}
