using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.UseCases;
using APIAeropuerto.Application.UseCases.Airport;
using APIAeropuerto.Application.UseCases.Client;
using APIAeropuerto.Application.UseCases.ClientService;
using APIAeropuerto.Application.UseCases.Installations;
using APIAeropuerto.Application.UseCases.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Repositories;
using AutoMapper.Extensions.ExpressionMapping;

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
        services.AddScoped<IUseCase<ClientDTO, CreateClientDTO>, CreateClientUseCase>();
        services.AddScoped<IUseCase<ClientDTO, UpdateClientDTO>, UpdateClientUseCase>();
        services.AddScoped<IUseCase<string, DeleteClientDTO>, DeleteClientUseCase>();
        services.AddScoped<IUseCase<ClientDTO, GetOneClientDTO>, GetOneClientUseCase>();
        services.AddScoped<IUseCase<GetlAllServicesClientDTO, GetOneClientDTO>, GetAllServicesClientUseCase>();
        services.AddScoped<IUseCase<string, AddServiceDTO>, AddServiceUseCase>();
        services.AddScoped<GetAllClientsUseCase>();
        //ClientsServices UseCases
        services.AddScoped<IUseCase<string, DeleteClientServiceDTO>, DeleteClientServiceUseCase>();
        
        //Repositories
        services.AddScoped<IBaseRepository<AirportEntity>, AirportRepository>();
        services.AddScoped<IBaseRepository<InstallationsEntity>, InstallationsRepository>();
        services.AddScoped<IBaseRepository<ServicesEntity>, ServiceRepository>();
        services.AddScoped<IBaseRepository<ClientEntity>, ClientRepository>();
        services.AddScoped<IBaseRepository<ClientServicesEntity>, ClientServiceRepository>();
        services.AddScoped<IAirportRepository, AirportRepository>();
        services.AddScoped<IInstallationRepository, InstallationsRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientServiceRepository, ClientServiceRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Core V1");
            });
        }
        else
        {
            app.UseHsts();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
    }
}