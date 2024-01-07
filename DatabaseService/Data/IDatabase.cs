using HelperLibrary.Models.API;
using HelperLibrary.Models.Base;

namespace DatabaseService.Data;

public interface IDatabase
{
    UserModel? User_Find(UserInfo user);
    UserModel? User_Get(string userId);
}