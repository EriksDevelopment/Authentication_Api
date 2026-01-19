using System.Security.Claims;
using Authentication_Api.Core.Interfaces;
using Authentication_Api.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("user-login")]
        public async Task<ActionResult<UserLoginResponseDto>> UserLogin(UserLoginRequestDto dto)
        {
            try
            {
                var result = await _userService.UserLoginAsync(dto);

                _logger.LogInformation("Login successfull.");
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while logging in user: {dto.User_Name}.", dto.User_Name);
                return StatusCode(500, "Something went wrong.");
            }
        }


        [Authorize(Roles = "User")]
        [HttpGet("user-info")]
        public async Task<ActionResult<UserInfoResponseDto>> UserInfo()
        {
            try
            {
                var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                var result = await _userService.UserInfoAsync(id);

                _logger.LogInformation("Info about user retrieved successfully");
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while retrieving info about user");
                return StatusCode(500, "Something went wrong.");
            }
        }

        [AllowAnonymous]
        [HttpPost("user-register")]
        public async Task<ActionResult<CreateUserResponseDto>> CreateUser(CreateUserRequestDto dto)
        {
            try
            {
                var result = await _userService.CreateUserAsync(dto);

                _logger.LogInformation("User successfully created.");
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while registering user");
                return StatusCode(500, "Something went wrong.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpDelete("user-delete")]
        public async Task<ActionResult<DeleteUserResponseDto>> DeleteUser(DeleteUserRequestDto dto)
        {
            try
            {
                var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                var result = await _userService.DeleteUserAsync(dto);

                _logger.LogInformation("User successfully deleted.");
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while deleting user.");
                return StatusCode(500, "Something went wrong.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet("view-friends")]
        public async Task<ActionResult<GetAllFriendsResponseDto>> GetFriends()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                var result = await _userService.GetFriendsAsync(userId);

                _logger.LogInformation("All friends retrieved successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong while retrieving all friends.");
                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}