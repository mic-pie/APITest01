using HelperLibrary.Models.v1.DB;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary.Models.v1.API;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class APIResponse
{
    public int Status { get; set; }
    public string Title { get { return GetTitle(); } }
    public List<Error>? Errors { get; set; } = null;
    public UserModel[]? Users { get; set; } = null;
    public JobOfferModel[]? JobOffers { get; set; } = null;


    public APIResponse(int statusCode)
    {
        Status = statusCode;
    }

    public APIResponse(int statusCode, List<Error>? errors = null)
    {
        Status = statusCode;
        Errors = errors;
    }

    public APIResponse(int statusCode, string? errorKey, string? errorValue)
    {
        Status = statusCode;

        if (string.IsNullOrWhiteSpace(errorKey) == false && string.IsNullOrWhiteSpace(errorValue) == false)
        {
            Errors = new() { new(errorKey, errorValue) };
        }
    }

    public APIResponse(int statusCode, UserModel user)
    {
        Status = statusCode;
        Users = [user];
    }

    public APIResponse(int statusCode, UserModel user, List<Error>? errors = null)
    {
        Status = statusCode;
        Users = [user];
        Errors = errors;
    }

    public APIResponse(int statusCode, UserModel user, string? errorKey = null, string? errorValue = null)
    {
        Status = statusCode;
        Users = [user];

        if (string.IsNullOrWhiteSpace(errorKey) == false && string.IsNullOrWhiteSpace(errorValue) == false)
        {
            Errors = new() { new(errorKey, errorValue) };
        }
    }

    public APIResponse(int statusCode, JobOfferModel jobOffer)
    {
        Status = statusCode;
        JobOffers = [jobOffer];
    }

    public APIResponse(int statusCode, JobOfferModel jobOffer, List<Error>? errors = null)
    {
        Status = statusCode;
        JobOffers = [jobOffer];
        Errors = errors;
    }

    public APIResponse(int statusCode, JobOfferModel jobOffer, string? errorKey = null, string? errorValue = null)
    {
        Status = statusCode;
        JobOffers = [jobOffer];

        if (string.IsNullOrWhiteSpace(errorKey) == false && string.IsNullOrWhiteSpace(errorValue) == false)
        {
            Errors = new() { new(errorKey, errorValue) };
        }
    }

    private string GetTitle()
    {
        switch (Status)
        {
            case 200:
                return "OK";
            case 404:
                return "Object not found";
            default:
                return "One or more errors occurred.";
        }
    }

}

public class Error
{
    public string Key { get; set; }
    public string[] Value { get; set; }


    public Error(string key, string value)
    {
        Key = key;
        Value = [value];
    }

    public override string ToString()
    {
        return $"Key: {Key}, Value: {Value}";
    }
}