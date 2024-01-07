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

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    public IActionResult GetUser([FromBody] UserInfo user)
    {
        try
        {
            // Validate incoming data
            if (user.IsValid(out Dictionary<string, string> errors) == false)
            {
                return BadRequest(Helpers.APIResponseProcessing.BuildModelStateDictionary(errors));
            }

            // Process
            UserModel? result  = _processing.User_Get(user);

            // Result
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GenerateTrainingCertificates");
            return StatusCode(500, ex.Message);
        }
    }

}
