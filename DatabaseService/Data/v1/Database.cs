using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DatabaseService.Data.v1;

public partial class Database : IDatabase
{
    private readonly ILogger<Database> _logger;
    private readonly IConfiguration _configuration;

    public Database(ILogger<Database> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_configuration.GetConnectionString("SqlServerConnection"));


}
