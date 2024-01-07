using HelperLibrary.Models.API;
using HelperLibrary.Models.Base;

using Microsoft.AspNetCore.Mvc;

using ProcessingService.Processing;

using System.Net.Mime;

namespace WebApi.Controllers.v1;

[ApiController, Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger _logger;
    private readonly IProcessing _processing;

    public UserController(ILogger logger, IProcessing processing)
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
            // Validate incoming data
            if (user.IsValid(out Dictionary<string, string> errors) == false)
            {
                return BadRequest(Helpers.APIResponseProcessing.BuildModelStateDictionary(errors));
            }

            // Process
            UserModel? result = _processing.User_Find(user);

            // Result
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GenerateTrainingCertificates");
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet("{userId}")]
    public IActionResult GetUserById(string userId)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest("User ID is required.");
            }

            UserModel? result = _processing.User_Get(userId);

            if (result == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {EndpointName} for User ID: {UserId}", "GetUserById", userId);
            return StatusCode(500, "Internal Server Error");
        }
    }


}
