using HelperLibrary.Models.v1.API;
using HelperLibrary.Models.v1.DB;

namespace DatabaseService.Data.ForTesting;

public class MockDatabaseService : IDatabase
{
    private readonly List<UserModel> _users;
    private readonly List<JobOfferModel> _jobOffers;

    public MockDatabaseService()
    {
        // Initialize with sample data
        _users = new List<UserModel>
        {
            new() { Id = "dwfuegxiqweyrbcinw", FirstName = "John", LastName = "Doe", Email="John.Doe@gmail.com"},
            new() { Id = "w4yconwey45iferfer", FirstName = "Jane", LastName = "Smith", Email="Jane.Smith@gmail.com"}
        };

        _jobOffers = new List<JobOfferModel>
        {
            new() { Id = "retfbyjuhdiy7iynikh", Company = "Company1", Title = "JobOffer1", IsActive = true },
            new() { Id = "sjdgbfvjs4ncisehcnk", Company = "Company2", Title = "JobOffer2", IsActive = false }
        };
    }

    #region Job Offer

    public bool JobOffer_Archive(string jobOfferId)
    {
        JobOfferModel? jobOffer = _jobOffers.Find(x => x.Id == jobOfferId);

        if (jobOffer == null)
            return true;

        jobOffer.IsActive = false;

        _jobOffers.RemoveAll(x => x.Id == jobOfferId);
        _jobOffers.Add(jobOffer);

        return true;
    }

    public JobOfferModel? JobOffer_Get(string jobOfferId, bool isActive = true)
    {
        return _jobOffers.Find(x => (x.Id == jobOfferId) && (x.IsActive = isActive));
    }

    public JobOfferModel? JobOffer_Update(JobOfferModel jobOffer)
    {
        _jobOffers.RemoveAll(x => x.Id == jobOffer.Id);
        _jobOffers.Add(jobOffer);
        return _jobOffers.Find(x => x.Id == jobOffer.Id);
    }

    #endregion

    #region User

    public UserModel? User_Find(UserInfo user)
    {
        return _users.Find(x => x.Id == user.Id || x.Email == user.Email);
    }

    public UserModel? User_Get(string userId)
    {
        return _users.Find(x => x.Id == userId);
    }

    public UserModel? User_Update(UserModel userModel)
    {
        _users.RemoveAll(x => x.Id == userModel.Id);
        _users.Add(userModel);
        return _users.Find(x => x.Id == userModel.Id);
    }

    #endregion
}