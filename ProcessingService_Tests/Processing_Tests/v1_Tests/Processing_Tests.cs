using DatabaseService.Data.ForTesting;

using Microsoft.Extensions.Logging;

using Moq;

using ProcessingService.Processing.v1;

namespace ProcessingService_Tests.Processing_Tests.v1_Tests;

public partial class Processing_Tests
{
    private readonly Mock<ILogger<Processing>> _mockLogger;
    private readonly Processing _processingService;

    public Processing_Tests()
    {
        _mockLogger = new Mock<ILogger<Processing>>();

        // Configure mock logger to write to console and file
        _mockLogger.Setup(
            l => l.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<object>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()
                ))
            .Callback<LogLevel, EventId, object, Exception, Func<object, Exception, string>>((logLevel, eventId, state, exception, formatter) =>
            {
                var message = formatter(state, exception);
                Console.WriteLine(message); // Output to console
                File.AppendAllText("log.txt", message + Environment.NewLine); // Append to a file
            });

        _processingService = new Processing(_mockLogger.Object, new MockDatabaseService());
        // Initialize your ProcessingService with the mocked logger and other dependencies if any
    }

}

