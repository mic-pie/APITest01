using HelperLibrary.Models.v1.API;
using HelperLibrary.Models.v1.DB;

namespace ProcessingService.Processing;

public interface IProcessing
{
    #region Company
    #endregion

    #region JobOffer
    JobOfferModel? JobOffer_Get(string jobOfferId);
    JobOfferModel? JobOffer_Update(JobOfferModel jobOffer);
    bool JobOffer_Delete(string jobOfferId);
    #endregion

    #region Tag
    #endregion

    #region User
    UserModel? User_Find(UserInfo user);
    UserModel? User_Get(string userId);
    UserModel? User_Update(UserModel user);
    #endregion

}