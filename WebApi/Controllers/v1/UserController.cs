using HelperLibrary.Models.v1.API;
using HelperLibrary.Models.v1.DB;

using Microsoft.AspNetCore.Mvc;

using ProcessingService.Processing;

using System.Net.Mime;

namespace WebApi.Controllers.v1;

[ApiController, Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IProcessing _processing;

    public UserController(ILogger<UserController> logger, IProcessing processing)
    {
        _logger = logger;
        _processing = processing;
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    public IActionResult FindUser([FromBody] UserInfo user)
    {
        try
        {
            // Validate
            if (user.IsValid(out List<Error> errors) == false)
            {
                APIResponse resp = new(400, errors);
                return BadRequest(resp);
            }

            // Process
            UserModel? result = _processing.User_Find(user);

            // Result
            if (result == null)
            {
                APIResponse resp = new(404, "User", $"User not found.");
                return NotFound(resp);
            }

            APIResponse response = new(200, result);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GenerateTrainingCertificates");
            return StatusCode(500, "Internal Server Error");
        }
    }


    [HttpGet("{userId}")]
    public IActionResult GetUserById(string userId)
    {
        try
        {
            // Validate
            if (string.IsNullOrWhiteSpace(userId))
            {
                APIResponse resp = new(400, "ID", "User ID required.");
                return BadRequest(resp);
            }

            // Process
            UserModel? result = _processing.User_Get(userId);

            // Result
            if (result == null)
            {
                APIResponse resp = new(404, "User", $"User with ID '{userId}' not found.");
                return NotFound(resp);
            }

            APIResponse response = new(200, result);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user with ID: {UserId}", userId);
            APIResponse resp = new(500, "Internal Server Error", $"Error getting user with ID: {userId}");
            return StatusCode(500, resp);
        }
    }

    [HttpPut("{userId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    public IActionResult UpdateUser(string userId, [FromBody] UserModel user)
    {
        try
        {
            // Validate
            if (userId != user.Id)
            {
                APIResponse resp = new(400, "ID", "User ID mismatch.");
                return BadRequest(resp);
            }

            // Process
            UserModel? result = _processing.User_Update(user);

            // Result
            if (result == null)
            {
                APIResponse resp = new(500, "Internal Server Error", $"Error updating user with ID: {userId}");
                return StatusCode(500, resp);
            }

            APIResponse response = new(200, result);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user with ID: {UserId}", userId);
            APIResponse resp = new(500, "Internal Server Error", $"Error updating user with ID: {userId}");
            return StatusCode(500, resp);
        }
    }



}
