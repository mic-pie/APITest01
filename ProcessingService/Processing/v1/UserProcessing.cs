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
    public UserModel? User_Get(UserInfo user)
    {
        try
        {
            UserModel userModel = new UserModel();

            return userModel;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error in GetUser");
            return null;
        }

    }
}
