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
    public const string WriteClient = "WriteClient";
    public const string ReadClient = "ReadClient";
    public const string WriteService = "WriteService";
    public const string ReadService = "ReadService";
    public const string WriteClientServices = "WriteClientServices";
    public const string ReadClientServices = "ReadClientServices";
    public const string WriteClientTypes = "WriteClientTypes";
    public const string ReadClientTypes = "ReadClientTypes";
    public const string WriteServiceTypes = "WriteServiceTypes";
    public const string ReadServiceTypes = "ReadServiceTypes";
    public const string WriteInstallations = "WriteInstallations";
    public const string ReadInstallations = "ReadInstallations";
    public const string WriteInstallationTypes = "WriteInstallationTypes";
    public const string ReadInstallationTypes = "ReadInstallationTypes";
    public const string WriteFlights = "WriteFlights";
    public const string ReadFlights = "ReadFlights";
    public const string WriteRepairs = "WriteRepairs";
    public const string ReadRepairs = "ReadRepairs";
    public const string WriteRepairServices = "WriteRepairServices";
    public const string ReadRepairServices = "ReadRepairServices";
    public const string WriteShips = "WriteShips";
    public const string ReadShips = "ReadShips";
}