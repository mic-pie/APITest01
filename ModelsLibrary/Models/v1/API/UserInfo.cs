using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using HelperLibrary.Helpers;

namespace HelperLibrary.Models.v1.API;

public class UserInfo
{
    public string? Id { get; set; }
    public string? Email { get; set; }

    public bool IsValid(out List<Error> errors)
    {
        errors = new();

        if (string.IsNullOrWhiteSpace(Email))
        {
            errors.Add(new("Email", "Email is required"));
        }
        else if (!Mailing.IsEmailValid(Email))
        {
            errors.Add(new("Email", "Email is not valid"));
        }

        if (string.IsNullOrWhiteSpace(Id))
        {
            errors.Add(new("Id", "Id is required"));
        }

        return errors.Count == 0;
    }
}
