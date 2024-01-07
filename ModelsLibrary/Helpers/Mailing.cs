using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HelperLibrary.Helpers;

public class Mailing
{
    public static bool SendMail(string recipientMail, string subject, string body, bool isBodyHtml)
    {
        MailMessage mailMessage = new()
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = isBodyHtml
        };

        foreach (var item in ParseMailAddresses(recipientMail))
        {
            mailMessage.To.Add(item);
        }

        if (mailMessage.To.Count == 0)
        {
            return false;
        }

        return SendMailMessage(mailMessage);
    }

    public static bool SendMail(string recipientMail, string subject, string body, bool isBodyHtml, string attachmentPath)
    {
        MailMessage mailMessage = new()
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = isBodyHtml
        };

        foreach (var item in ParseMailAddresses(recipientMail))
        {
            mailMessage.To.Add(item);
        }

        if (mailMessage.To.Count == 0)
        {
            return false;
        }

        if (File.Exists(attachmentPath))
        {
            mailMessage.Attachments.Add(new Attachment(attachmentPath));
        }

        return SendMailMessage(mailMessage);
    }

    public static bool SendMail(string recipientMail, string subject, string body, bool isBodyHtml, List<string> attachmentPaths)
    {
        MailMessage mailMessage = new()
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = isBodyHtml
        };

        foreach (var item in ParseMailAddresses(recipientMail))
        {
            mailMessage.To.Add(item);
        }

        if (mailMessage.To.Count == 0)
        {
            return false;
        }

        foreach (string path in attachmentPaths)
        {
            if (File.Exists(path))
            {
                mailMessage.Attachments.Add(new Attachment(path));
            }
        }

        return SendMailMessage(mailMessage);
    }

    public static bool SendMail(List<string> recipientMails, string subject, string body, bool isBodyHtml)
    {
        MailMessage mailMessage = new()
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = isBodyHtml
        };

        foreach (string mail in recipientMails)
        {
            if (IsEmailValid(mail))
            {
                mailMessage.To.Add(mail);
            }
        }

        if (mailMessage.To.Count == 0)
        {
            return false;
        }

        return SendMailMessage(mailMessage);
    }

    public static bool SendMail(List<string> recipientMails, string subject, string body, bool isBodyHtml, string attachmentPath)
    {
        MailMessage mailMessage = new()
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = isBodyHtml
        };

        foreach (string mail in recipientMails)
        {
            if (IsEmailValid(mail))
            {
                mailMessage.To.Add(mail);
            }
        }

        if (mailMessage.To.Count == 0)
        {
            return false;
        }

        if (File.Exists(attachmentPath))
        {
            mailMessage.Attachments.Add(new Attachment(attachmentPath));
        }

        return SendMailMessage(mailMessage);
    }

    public static bool SendMail(List<string> recipientMails, string subject, string body, bool isBodyHtml, List<string> attachmentPaths)
    {
        MailMessage mailMessage = new()
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = isBodyHtml
        };

        foreach (string mail in recipientMails)
        {
            if (IsEmailValid(mail))
            {
                mailMessage.To.Add(mail);
            }
        }

        if (mailMessage.To.Count == 0)
        {
            return false;
        }

        foreach (string path in attachmentPaths)
        {
            if (File.Exists(path))
            {
                mailMessage.Attachments.Add(new Attachment(path));
            }
        }

        return SendMailMessage(mailMessage);
    }

    public static bool SendMail(string to, string cc, string bcc, string responseMail, string subject, string body, bool isBodyHtml, string attachment = "")
    {
        MailMessage mailMessage = new()
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = isBodyHtml
        };

        foreach (var item in ParseMailAddresses(to))
        {
            mailMessage.To.Add(item);
        }

        foreach (var item in ParseMailAddresses(cc))
        {
            mailMessage.CC.Add(item);
        }

        foreach (var item in ParseMailAddresses(bcc))
        {
            mailMessage.Bcc.Add(item);
        }

        foreach (var item in ParseMailAddresses(responseMail))
        {
            mailMessage.ReplyToList.Add(item);
        }

        if (!string.IsNullOrWhiteSpace(attachment) && File.Exists(attachment))
        {
            mailMessage.Attachments.Add(new Attachment(attachment));
        }

        if (mailMessage.To.Count == 0)
        {
            return false;
        }

        return SendMailMessage(mailMessage);
    }

    /// <summary>
    /// Determines whether the specified email address is valid according to a regular expression pattern.
    /// </summary>
    /// <param name="email">The email address to validate.</param>
    /// <returns>True if the email address is valid; otherwise, false.</returns>
    public static bool IsEmailValid(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsEmailValidOld(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        string pattern = @"^(?=.{1,256})([^\s@]+)@((?!-)[A-Za-z0-9-]{1,63}(?<!-)\.)+[A-Za-z]{2,6}$";

        Regex regex = new(pattern, RegexOptions.IgnoreCase);
        bool result = regex.IsMatch(email);
        return result;
    }

    /// <summary>
    /// Parses a string of email addresses separated by semicolons and returns a list of valid addresses.
    /// </summary>
    /// <param name="mailAddresses">A string containing one or more email addresses separated by semicolons.</param>
    /// <returns>A List of strings representing the valid email addresses in the input string.</returns>
    public static List<string> ParseMailAddresses(string mailAddresses)
    {
        List<string> result = new();

        if (string.IsNullOrWhiteSpace(mailAddresses))
        {
            return result;
        }

        string[] colection = mailAddresses.Replace(" ", ";").Replace(",",";").Split(';');
        foreach (string addr in colection)
        {
            if (!string.IsNullOrWhiteSpace(addr) && IsEmailValid(addr))
                result.Add(addr);
        }

        return result.Distinct().ToList();
    }

    /// <summary>
    /// Sends a MailMessage using the specified SMTP client and credentials.
    /// </summary>
    /// <param name="mailMessage">The MailMessage to send.</param>
    /// <returns>True if the message was sent successfully, otherwise False.</returns>
    public static bool SendMailMessage(MailMessage mailMessage)
    {
        string mailFrom = "";
        string pass = @"";

        mailMessage.From = new MailAddress(mailFrom);

        SmtpClient smtpClient = new("")
        {
            //UseDefaultCredentials = false,
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(mailFrom, pass),
        };

        smtpClient.Send(mailMessage);

        return true;
    }
}

