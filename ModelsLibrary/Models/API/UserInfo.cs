using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using HelperLibrary.Helpers;

namespace HelperLibrary.Models.API;

public class UserInfo
{
    public string? Id { get; set; }
    public string? Email { get; set; }

    public bool IsValid(out Dictionary<string, string> errors)
    {
        errors = new Dictionary<string, string>();

        if (string.IsNullOrWhiteSpace(Email))
        {
            errors.Add("Email", "Email is required");
        }
        else if (!Mailing.IsEmailValid(Email))
        {
            errors.Add("Email", "Email is not valid");
        }

        if (string.IsNullOrWhiteSpace(Id))
        {
            errors.Add("Id", "Id is required");
        }

        return errors.Count <= 1;
    }

}
