namespace HelperLibrary.Models.v1.DB;
public class JobOfferModel
{
    public string Id { get; set; } // Unique identifier for the job offer
    public string Title { get; set; } // Job title
    public string Description { get; set; } // Detailed description of the job offer
    public string Company { get; set; } // Company offering the job
    public string Location { get; set; } // Location of the job
    public DateTime PostedDate { get; set; } // When the job offer was posted
    public DateTime ApplicationDeadline { get; set; } // Deadline for applications
    public string SalaryRange { get; set; } // Expected salary range
    public string EmploymentType { get; set; } // Type of employment (e.g., Full-time, Part-time, Contract)
    public bool IsActive { get; set; } = true;
}
