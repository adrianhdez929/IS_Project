using System.Net;
using System.Net.Mail;
using System.Text;
using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Application.DTOs.Auth;
using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Application.DTOs.Email;
using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Application.DTOs.RoleClaims;
using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Application.DTOs.UserClaims;
using APIAeropuerto.Application.DTOs.UserLogin;
using APIAeropuerto.Application.DTOs.UserRoles;
using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Application.UseCases.Airport;
using APIAeropuerto.Application.UseCases.Auth;
using APIAeropuerto.Application.UseCases.Client;
using APIAeropuerto.Application.UseCases.ClientService;
using APIAeropuerto.Application.UseCases.Email;
using APIAeropuerto.Application.UseCases.Flight;
using APIAeropuerto.Application.UseCases.Installations;
using APIAeropuerto.Application.UseCases.RepairService;
using APIAeropuerto.Application.UseCases.RoleClaims;
using APIAeropuerto.Application.UseCases.Roles;
using APIAeropuerto.Application.UseCases.Services;
using APIAeropuerto.Application.UseCases.Ship;
using APIAeropuerto.Application.UseCases.Token;
using APIAeropuerto.Application.UseCases.UserClaims;
using APIAeropuerto.Application.UseCases.UserLogin;
using APIAeropuerto.Application.UseCases.UserRoles;
using APIAeropuerto.Application.UseCases.Users;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using APIAeropuerto.Persistence.Entities;
using APIAeropuerto.Persistence.Repositories;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace APIAeropuerto;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddExpressionMapping();
            cfg.ShouldUseConstructor = ci => !ci.IsPrivate;
        }, typeof(Startup));
        services.AddSwaggerGen();
        services.ConfigureDbContext(Configuration);
        services.AddControllers();
        services.ConfigureIdentity();
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme, cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JWT_ISSUER"],
                        ValidateLifetime = true,
                        ValidAudience = Configuration["JWT_AUDIENCE"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT_KEY"]))
                    };
                });
        
        services.AddAuthorization(opt =>
        {
            string[] claims =
            {
               ClaimsStrings.ReadAirport,
               ClaimsStrings.WriteAirport,
               ClaimsStrings.ReadRoleClaims,
               ClaimsStrings.WriteRoleClaims,
               ClaimsStrings.ReadUser,
               ClaimsStrings.WriteUser,
               ClaimsStrings.ReadRole,
               ClaimsStrings.WriteRole,
               ClaimsStrings.ReadUserClaims,
               ClaimsStrings.WriteUserClaims,
               ClaimsStrings.ReadUserRoles,
               ClaimsStrings.WriteUserRoles
                
            };
            foreach (var claim in claims)
            {
                opt.AddPolicy(claim, policy => policy.RequireClaim("Auth", claim));
            }
        });
        //UsesCases
        //Airport UseCases
        services.AddScoped<IUseCase<AirportDTO,CreateAirportDTO>, CreateAirportUseCase>();
        services.AddScoped<IUseCase<AirportDTO, UpdateAirportDTO>, UpdateAirportUseCase>();
        services.AddScoped<IUseCase<string, DeleteAirportDTO>, DeleteAirportUseCase>();
        services.AddScoped<IUseCase<AirportDTO, GetOneAirportDTO>, GetOneAirportUseCase>();
        services.AddScoped<IUseCase<GetAirportInstDTO, GetOneAirportDTO>, GetAirportInstUseCase>();
        services.AddScoped<GetAllAirportUseCase>();
        //Installations UseCases
        services.AddScoped<IUseCase<InstallationDTO, CreateInstallationsDTO>, CreateInstallationUseCase>();
        services.AddScoped<IUseCase<InstallationDTO, UpdateInstallationDTO>, UpdateInstallationUseCase>();
        services.AddScoped<IUseCase<string, DeleteInstallationDTO>, DeleteInstallationUseCase>();
        services.AddScoped<IUseCase<InstallationDTO, GetOneInstallationDTO>, GetOneInstallationUseCase>();
        services
            .AddScoped<IUseCase<GetInstallationServicesDTO, GetOneInstallationDTO>, GetInstallationServicesUseCase>();
        services.AddScoped<GetAllInstallationUseCase>();
        //Services UseCases
        services.AddScoped<IUseCase<ServiceDTO, CreateServiceDTO>, CreateServiceUseCase>();
        services.AddScoped<IUseCase<string, DeleteServiceDTO>, DeleteServiceUseCase>();
        services.AddScoped<IUseCase<ServiceDTO, GetOneServiceDTO>, GetOneServiceUseCase>();
        services.AddScoped<IUseCase<ServiceDTO, UpdateServiceDTO>, UpdateServiceUseCase>();
        services.AddScoped<IUseCase<GetAllClientsServiceDTO, GetOneServiceDTO>, GetAllClientsServiceUseCase>();
        services.AddScoped<GetAllServicesUseCase>();
        //Clients UseCases
        services.AddScoped<IUseCase<ClientDTO, UpdateClientDTO>, UpdateClientUseCase>();
        services.AddScoped<IUseCase<string, DeleteClientDTO>, DeleteClientUseCase>();
        services.AddScoped<IUseCase<ClientDTO, GetOneClientDTO>, GetOneClientUseCase>();
        services.AddScoped<IUseCase<GetlAllServicesClientDTO, GetOneClientDTO>, GetAllServicesClientUseCase>();
        services.AddScoped<IUseCase<string, AddServiceDTO>, AddServiceUseCase>();
        services.AddScoped<GetAllClientsUseCase>();
        //ClientsServices UseCases
        services.AddScoped<IUseCase<string, DeleteClientServiceDTO>, DeleteClientServiceUseCase>();
        //Users UseCases
        services.AddScoped<IUseCase<UsersDTO, CreateUserDTO>, CreateUserUseCase>();
        services.AddScoped<IUseCase<UsersDTO, UpdateUserDTO>, UpdateUserUseCase>();
        services.AddScoped<IUseCase<string, DeleteUserDTO>, DeleteUserUseCase>();
        services.AddScoped<IUseCase<UsersDTO, GetOneUserDTO>, GetOneUserUseCase>();
        services.AddScoped<GetAllUsersUseCase>();
        //Roles UseCases
        services.AddScoped<IUseCase<RoleDTO, CreateRoleDTO>, CreateRoleUseCase>();
        services.AddScoped<IUseCase<RoleDTO, UpdateRoleDTO>, UpdateRoleUseCase>();
        services.AddScoped<IUseCase<string, DeleteRoleDTO>, DeleteRoleUseCase>();
        services.AddScoped<IUseCase<RoleDTO, GetOneRoleDTO>, GetOneRoleUseCase>();
        services.AddScoped<GetAllRolesUseCase>();
        //RoleClaims UseCases
        services.AddScoped<IUseCase<IEnumerable<RoleClaimsDTO>, GetAllRoleClaimsDTO>, GetAllRoleClaimsUseCase>();
        services.AddScoped<IUseCase<string,DeleteRoleClaimsDTO>, DeleteRoleClaimsUseCase>();
        //UserClaims UseCases
        services.AddScoped<IUseCase<IEnumerable<UserClaimsDTO>, GetAllUserClaimsDTO>, GetAllUserClaimsUseCase>();
        services.AddScoped<IUseCase<string, DeleteUserClaimsDTO>, DeleteUserClaimsUseCase>();
        //UserRoles UseCases
        services.AddScoped<IUseCase<IEnumerable<UserRolesDTO>, GetAllUserRolesDTO>, GetAllUserRolesUseCase>();
        services.AddScoped<IUseCase<string, DeleteUserRolesDTO>, DeleteUserRolesUseCase>();
        services.AddScoped<IUseCase<string, AddRolesToUserDTO>, AddRolesToUserUseCase>();
        //UserLogin UseCases
        services.AddScoped<IUseCase<UserLoginDTO, CredentialModelDTO>, LoginUseCase>();
        services.AddScoped<IUseCase<string, ForgetPasswordDTO>, ForgetPasswordUseCase>();
        services.AddScoped<ISendEmailUseCase<EmailDTO>, SendEmailUseCase>();
        services.AddScoped<IUseCase<string,ResetPasswordDTO>,ResetPasswordUseCase>();
        services.AddScoped<CreateTokenUseCase>();
        //Ship UseCases
        services.AddScoped<IUseCase<ShipDTO, CreateShipDTO>, CreateShipUseCase>();
        services.AddScoped<IUseCase<ShipDTO, UpdateShipDTO>, UpdateShipUseCase>();
        services.AddScoped<IUseCase<string, DeleteShipDTO>, DeleteShipUseCase>();
        services.AddScoped<IUseCase<ShipDTO, GetOneShipDTO>, GetOneShipUseCase>();
        services.AddScoped<GetAllShipsUseCase>();
        //RepairService UseCases
        services.AddScoped<IUseCase<ServiceDTO, CreateRepairServiceDTO>, CreateRepairServiceUseCase>();
        //Flights UseCases
        services.AddScoped<IUseCase<FlightDTO, CreateFlightDTO>, CreateFlightUseCase>();
        services.AddScoped<IUseCase<FlightDTO, UpdateFlightDTO>, UpdateFlightUseCase>();
        services.AddScoped<IUseCase<string, DeleteFlightDTO>, DeleteFlightUseCase>();
        services.AddScoped<IUseCase<FlightDTO, GetOneFlightDTO>, GetOneFlightUseCase>();
        services.AddScoped<GetAllFlightsUseCase>();
        //Repositories
        services.AddScoped<IBaseRepository<AirportEntity>, AirportRepository>();
        services.AddScoped<IBaseRepository<InstallationsEntity>, InstallationsRepository>();
        services.AddScoped<IBaseRepository<ServicesEntity>, ServiceRepository>();
        services.AddScoped<IBaseRepository<ClientEntity>, ClientRepository>();
        services.AddScoped<IBaseRepository<ClientServicesEntity>, ClientServiceRepository>();
        services.AddScoped<IBaseRepository<ShipEntity>, ShipRepository>();
        services.AddScoped<IBaseRepository<FlightEntity>, FlightRepository>();
        services.AddScoped<IAirportRepository, AirportRepository>();
        services.AddScoped<IInstallationRepository, InstallationsRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientServiceRepository, ClientServiceRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IShipRepository, ShipRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<RoleManager<RolePersistence>>();
        services.AddScoped<UserManager<UserPersistence>>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddSingleton<SmtpClient>(s => new SmtpClient(Configuration["Smtp:Host"])
        {
            Port = Convert.ToInt32(Configuration["Smtp:Port"]),
            Credentials = new NetworkCredential(Configuration["Smtp:Username"], 
                Configuration["Smtp:Password"]),
            EnableSsl = Convert.ToBoolean(Configuration["Smtp:UseSsl"])
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureDatabase();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Core V1");
            });
        }
        else
        {
            app.UseHsts();
        }
        app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
    }
}