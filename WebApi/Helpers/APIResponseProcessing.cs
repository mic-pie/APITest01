using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Helpers;

public class APIResponseProcessing
{
    public static ModelStateDictionary BuildModelStateDictionary(Dictionary<string, string> valuePairs)
    {
        ModelStateDictionary result = new();

        foreach (var valuePair in valuePairs)
        {
            result.AddModelError(valuePair.Key, valuePair.Value);
        }

        return result;
    }
}
