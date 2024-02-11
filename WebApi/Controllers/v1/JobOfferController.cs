using HelperLibrary.Models.v1.DB;

using Microsoft.AspNetCore.Mvc;

using ProcessingService.Processing;

using System.Net.Mime;

namespace WebApi.Controllers.v1;

[ApiController, Route("api/[controller]")]
public class JobOfferController : Controller
{
    private readonly ILogger<JobOfferController> _logger;
    private readonly IProcessing _processing;

    public JobOfferController(ILogger<JobOfferController> logger, IProcessing processing)
    {
        _logger = logger;
        _processing = processing;
    }

    [HttpGet("{jobOfferId}")]
    public IActionResult GetJobOfferById(string jobOfferId)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(jobOfferId))
            {
                return BadRequest("Job Offer ID is required.");
            }

            JobOfferModel? result = _processing.JobOffer_Get(jobOfferId);

            if (result == null)
            {
                return NotFound($"Job Offer with ID {jobOfferId} not found.");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {EndpointName} for Job Offer ID: {UserId}", "GetJobOfferById", jobOfferId);
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPut("{jobOfferId}")]
    public IActionResult UpdateUser(string jobOfferId, [FromBody] JobOfferModel jobOffer)
    {
        try
        {
            if (jobOfferId != jobOffer.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            JobOfferModel? result = _processing.JobOffer_Update(jobOffer);

            if (result == null)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user with ID: {UserId}", jobOfferId);
            return StatusCode(500, "Internal Server Error");
        }
    }



}
