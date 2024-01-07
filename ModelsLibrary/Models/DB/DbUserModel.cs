using HelperLibrary.Models.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.Models.DB;

public class DbUserModel : UserModel
{
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdate { get; set; }

}
