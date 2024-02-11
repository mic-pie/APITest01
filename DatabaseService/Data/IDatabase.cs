using HelperLibrary.Models.v1.API;
using HelperLibrary.Models.v1.DB;

namespace DatabaseService.Data;

public interface IDatabase
{
    bool JobOffer_Archive(string jobOfferId);
    JobOfferModel? JobOffer_Get(string jobOfferId, bool isActive = true);
    JobOfferModel? JobOffer_Update(JobOfferModel jobOffer);
    UserModel? User_Find(UserInfo user);
    UserModel? User_Get(string userId);
    UserModel? User_Update(UserModel userModel);
}