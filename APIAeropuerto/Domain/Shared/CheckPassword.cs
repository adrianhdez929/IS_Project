namespace APIAeropuerto.Domain.Shared;

public class CheckPassword
{
    public static string Check(string password)
    {
        if (string.IsNullOrEmpty(password))
            return "Password is required";
        if (password.Length < 8)
            return "Password must be at least 8 characters long";
        if (!password.Any(char.IsUpper))
            return "Password must have at least one uppercase letter";
        if (!password.Any(char.IsLower))
            return "Password must have at least one lowercase letter";
        if (!password.Any(char.IsDigit))
            return "Password must have at least one number";
        if (!password.Any(char.IsPunctuation))
            return "Password must have at least one special character";
        return string.Empty;
    }
}