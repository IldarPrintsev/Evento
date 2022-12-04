using System.Globalization;
using System.Text.RegularExpressions;
using Evento.Domain.SeedWork;

namespace Evento.Domain.Users.Rules;

public class UserEmailRule : ISyncBusinessRule
{
    private readonly string _userEmail;

    public UserEmailRule(string userEmail)
        => _userEmail = userEmail;

    public string Message
        => $"Email format is wrong";

    public bool Verify()
    {
        if (string.IsNullOrWhiteSpace(_userEmail))
        {
            return false;
        }

        string email;

        try
        {
            // Normalize the domain
            email = Regex.Replace(_userEmail, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            static string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}
