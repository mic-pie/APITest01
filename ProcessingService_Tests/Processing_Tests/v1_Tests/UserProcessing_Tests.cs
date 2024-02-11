using HelperLibrary.Models.v1.API;

using Xunit;

namespace ProcessingService_Tests.Processing_Tests.v1_Tests;

public partial class Processing_Tests
{
    [Theory]
    [InlineData("dwfuegxiqweyrbcinw", true)]
    [InlineData("w4yconwey45iferfer", true)]
    [InlineData("AlaMaKota", false)]
    public void User_Get_WithValidId_ReturnsUser(string userId, bool exists)
    {
        // Act
        var result = _processingService.User_Get(userId);

        // Assert
        if (exists)
        {
            Assert.NotNull(result);
        }
        else
        {
            Assert.Null(result);
        }
    }

    [Theory]
    [InlineData("123", "test@example.com", false)]
    [InlineData("456", "invalid-email", false)]
    [InlineData("", "test@example.com", false)]
    [InlineData(null, "test@example.com", false)]
    [InlineData("dwfuegxiqweyrbcinw", null, true)]
    [InlineData("", "Jane.Smith@gmail.com", true)]
    public void User_Find_ValidatesUserInfo_ReturnsUserModelOrNull(string? id, string? email, bool exists)
    {
        // Arrange
        var userInfo = new UserInfo { Id = id, Email = email };

        // Act
        var result = _processingService.User_Find(userInfo);

        // Assert
        if (exists)
        {
            Assert.NotNull(result);
            Assert.NotNull(result.Id);

            if(!string.IsNullOrEmpty(id))
                Assert.Equal(result.Id, id);
        }
        else
        {
            Assert.Null(result);
        }
    }
}
