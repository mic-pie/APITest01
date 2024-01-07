using HelperLibrary.Models.API;
using HelperLibrary.Models.Base;

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
            UserModel userModel = new() { Id=user.Id, Email=user.Email};

            return userModel;
        }
        catch(Exception ex)
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
            UserModel userModel = new();

            return userModel;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in User_Get");
            return null;
        }
    }
}
