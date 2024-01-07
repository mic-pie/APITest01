using HelperLibrary.Models.API;
using HelperLibrary.Models.Base;

namespace ProcessingService.Processing;

public interface IProcessing
{
    #region User
    UserModel? User_Find(UserInfo user);
    UserModel? User_Get(string userId);

    #endregion

    #region Company
    #endregion

    #region JobOffer
    #endregion

    #region Tag
    #endregion

}