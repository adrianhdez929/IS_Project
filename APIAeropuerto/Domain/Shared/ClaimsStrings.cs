using System.Reflection;

namespace APIAeropuerto.Domain.Shared;

public class ClaimsStrings
{
    public static readonly string[] BasePermissions;

    static ClaimsStrings()
    {
        BasePermissions = typeof(ClaimsStrings)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(x => x.IsLiteral && !x.IsInitOnly && x.FieldType == typeof(string))
            .Select(x => (string)x.GetRawConstantValue())
            .ToArray();
    }
    
    public const string ReadAirport = "ReadAirport";
    public const string WriteAirport = "WriteAirport";
    public const string ReadRoleClaims = "ReadRoleClaims";
    public const string WriteRoleClaims = "WriteRoleClaims";
    public const string ReadUser = "ReadUser";
    public const string WriteUser = "WriteUser";
    public const string ReadRole = "ReadRole";
    public const string WriteRole = "WriteRole";
    public const string ReadUserClaims = "ReadUserClaims";
    public const string WriteUserClaims = "WriteUserClaims";
    public const string ReadUserRoles = "ReadUserRoles";
    public const string WriteUserRoles = "WriteUserRoles";
}