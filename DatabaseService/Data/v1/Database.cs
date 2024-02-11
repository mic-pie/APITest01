using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HelperLibrary.Models.v1.DB;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DatabaseService.Data.v1;

public partial class Database : IDatabase
{
    private readonly ILogger<Database> _logger;
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public Database(ILogger<Database> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _connection = CreateConnection();
        _connection.Open();
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_configuration.GetConnectionString("Default"));


}
