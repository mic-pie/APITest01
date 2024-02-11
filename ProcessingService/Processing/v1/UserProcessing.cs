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
    public UserModel? User_Find(UserInfo user)
    {
        try
        {
            // Check if user exists in DB
            UserModel? userModel = _database.User_Find(user);

            return userModel;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in User_Find");
            return null;
        }

    }

    public UserModel? User_Get(string userId)
    {
        try
        {
            // Find User in DB
            UserModel? userModel = _database.User_Get(userId);

            return userModel;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in User_Get");
            return null;
        }
    }

    public UserModel? User_Update(UserModel user)
    {
        try
        {
            // Validate the user

            // Call the database layer to update the user
            return _database.User_Update(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in User_Get");
            return null;
        }
    }
}
