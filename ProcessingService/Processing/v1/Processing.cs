using DatabaseService.Data;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingService.Processing.v1;

public partial class Processing : IProcessing
{
    private readonly ILogger<Processing> _logger;
    private readonly IDatabase _database;

    public Processing(ILogger<Processing> logger, IDatabase database)
    {
        _logger = logger;
        _database = database;
    }

}
