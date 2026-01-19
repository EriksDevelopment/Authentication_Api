using System.Security.Claims;
using Authentication_Api.Core.Interfaces;
using Authentication_Api.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserFriendController : ControllerBase
    {
        private readonly IUserFriendService _userService;
        private readonly ILogger<UserController> _logger;

        public UserFriendController(IUserFriendService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [Authorize(Roles = "User")]
        [HttpPost("add-friend")]
        public async Task<ActionResult<AddFriendResponseDto>> AddFriend([FromBody] AddFriendRequestDto dto)
        {
            try
            {
                var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                var result = await _userService.AddFriendAsync(currentUserId, dto.Friend_User_Key);

                _logger.LogInformation("Friend added successfully");
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while adding friend.");
                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}