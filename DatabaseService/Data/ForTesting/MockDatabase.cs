using HelperLibrary.Models.API;
using HelperLibrary.Models.Base;

namespace DatabaseService.Data.ForTesting;

public class MockDatabaseService : IDatabase
{
    private readonly List<UserModel> _users;

    public MockDatabaseService()
    {
        // Initialize with sample data
        _users = new List<UserModel>
        {
            new() { Id = "dwfuegxiqweyrbcinw", FirstName = "John", LastName = "Doe", Email="John.Doe@gmail.com"},
            new(){ Id = "w4yconwey45iferfer", FirstName = "Jane", LastName = "Smith", Email="Jane.Smith@gmail.com"}
        };
    }

    public UserModel? User_Find(UserInfo user)
    {
        return _users.Find(x => x.Id == user.Id || x.Email == user.Email);
    }

    public UserModel? User_Get(string userId)
    {
        return _users.Find(x => x.Id == userId);
    }
}