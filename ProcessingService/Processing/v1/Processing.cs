using HelperLibrary.Models.Base;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingService.Processing.v1;

public partial class Processing : IProcessing
{
    private readonly ILogger _logger;

    public Processing(ILogger<Processing> logger)
    {
        _logger = logger;
    }

}
