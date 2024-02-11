using HelperLibrary.Models.v1.API;
using HelperLibrary.Models.v1.DB;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingService.Processing.v1;

public partial class Processing
{
    public JobOfferModel? JobOffer_Get(string jobOfferId)
    {
        try
        {
            JobOfferModel? jobOfferModel = _database.JobOffer_Get(jobOfferId);

            return jobOfferModel;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in JobOffer_Get");
            return null;
        }
    }

    public JobOfferModel? JobOffer_Update(JobOfferModel jobOffer)
    {
        try
        {
            JobOfferModel? jobOfferModel = _database.JobOffer_Update(jobOffer);

            return jobOfferModel;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in JobOffer_Update");
            return null;
        }
    }

    public bool JobOffer_Delete(string jobOfferId)
    {
        try
        {
            return _database.JobOffer_Archive(jobOfferId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in JobOffer_Delete");
            return false;
        }
    }
}
