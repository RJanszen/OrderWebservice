using Microsoft.AspNetCore.Mvc;
using Optimizers.Order.Services.Contracts.DTO.User;
using Optimizers.Order.Services.Contracts.Interfaces;

namespace Optimizers.Order.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.Get();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id">The id of the user</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="dto">A dto containing the new user</param>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(CreateUserDTO dto)
        {
            var user = await _userService.Create(dto);

            return CreatedAtAction(nameof(Create), user);
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="id">The id of the user to update</param>
        /// <param name="outboundDelivery">A dto containing the update</param>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(long id, UpdateUserDTO dto)
        {
            var user = await _userService.Update(id, dto);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Deletes an existing user
        /// </summary>
        /// <param name="id">The id of the user to delete</param>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await _userService.Delete(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
