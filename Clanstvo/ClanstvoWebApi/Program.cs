using Clanstvo.Repositories;
using Clanstvo.Repositories.SqlServer;
using Clanstvo.DataAccess.SqlServer.Data;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Clanstvo.Providers;
using Clanstvo.Providers.Http;

var builder = WebApplication.CreateBuilder(args);

// create a configuration (app settings) from the appsettings file, depending on the ENV
IConfiguration configuration = builder.Environment.IsDevelopment()
 ? builder.Configuration.AddJsonFile("appsettings.Development.json").Build()
 : builder.Configuration.AddJsonFile("appsettings.json").Build();
//version updated

// EDIT
// register the DbContext - EF ORM
// this allows the DbContext to be injected
builder.Services.AddDbContext<ClanstvoContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("ClanstvoDB")));
builder.Services.AddTransient<IClanRepository, ClanRepository>();
builder.Services.AddTransient<IClanarinaRepository, ClanarinaRepository>();
builder.Services.AddTransient<IRangStarostRepository, RangStarostRepository>();
builder.Services.AddTransient<IRangZaslugaRepository, RangZaslugaRepository>();
builder.Services.AddTransient<IAkcijeSkoleProvider, AkcijeSkoleProvider>();

HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

builder.Services.AddHttpClient("Udruge", client =>
{
    client.BaseAddress = new Uri(builder.Configuration
            .GetSection("RemoteServices").GetValue<String>("Udruge"));
}).ConfigurePrimaryHttpMessageHandler(x => clientHandler);

builder.Services.AddHttpClient("Akcije/Skole", client =>
{
    client.BaseAddress = new Uri(builder.Configuration
        .GetSection("RemoteServices").GetValue<String>("AkcijeSkole"));
}).ConfigurePrimaryHttpMessageHandler(x => clientHandler);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
