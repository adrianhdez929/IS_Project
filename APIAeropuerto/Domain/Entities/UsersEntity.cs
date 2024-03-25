using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Domain.Entities;

public class UsersEntity : IdentityUser<Guid>
{
    public DateTime LastLogin { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    public virtual ICollection<UserClaimEntity> UserClaims { get; set; }
    public virtual ICollection<UserLoginEntity> UserLogins { get; set; }
    public UsersEntity(Guid id,string name, string email, string password)
    {
        Id = id;
        UserName = name;
        Email = email;
        PasswordHash = password;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    public static UsersWrapper Create(string name, string email, string password)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            return new UsersWrapper
            {
                IsSuccess = false,
                ErrorMessage = "Name, email and password are required",
                Value = null!
            };
        if(name.Length < 3)
            return new UsersWrapper
            {
                IsSuccess = false,
                ErrorMessage = "Name is required and must be at least 3 characters long",
                Value = null!
            };
        var check = CheckEmail(email);
        if (!check.IsSuccess) return check;
        var user = new UsersEntity(Guid.NewGuid(), name, email, password);
        return new UsersWrapper
        {
            IsSuccess = true,
            ErrorMessage = string.Empty,
            Value = user
        };
    }

    public static UsersWrapper CheckEmail(string email)
    {
        if(string.IsNullOrWhiteSpace(email)) 
            return new UsersWrapper()
            {
                IsSuccess = false,
                ErrorMessage = "Email not valid",
                Value = null!
            };
        try
        {
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if(!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
                return new UsersWrapper()
                {
                    IsSuccess = false,
                    ErrorMessage = "Email not valid",
                    Value = null!
                };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return new UsersWrapper()
        {
            IsSuccess = true,
            ErrorMessage = null,
            Value = null,
        };
    }
    private static string DomainMapper(Match match)
    {
        var idn = new IdnMapping();
        var domainName = match.Groups[2].Value;
        try
        {
            domainName = idn.GetAscii(domainName);
        }
        catch (ArgumentException)
        {
            throw new Exception("Email not valid");
        }
        return match.Groups[1].Value + domainName;
    }
    public void Update(string name, string email, string password)
    {
        UserName = name;
        Email = email;
        PasswordHash = password;
        Updated = DateTime.Now;
    }
}