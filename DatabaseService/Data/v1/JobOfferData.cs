using HelperLibrary.Models.v1.DB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Data.v1;

public partial class Database
{
    public bool JobOffer_Archive(string jobOfferId)
    {
        throw new NotImplementedException();
    }

    public JobOfferModel? JobOffer_Get(string jobOfferId, bool isActive = true)
    {
        throw new NotImplementedException();
    }

    public JobOfferModel? JobOffer_Update(JobOfferModel jobOffer)
    {
        throw new NotImplementedException();
    }
}
