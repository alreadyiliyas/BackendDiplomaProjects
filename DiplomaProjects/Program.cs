using DiplomaProjects.Core.Abstractions.RepositoryAbstractions;
using DiplomaProjects.DataAccess;
using DiplomaProjects.DataAccess.MapProfiles;
using DiplomaProjects.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DiplomaProjects.Endpoints;
using DiplomaProjects.Infrastructure.Authentication;
using DiplomaProjects.Application.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DiplomaProjects.Core.Models;
using DiplomaProjects.Application.Services.AddressService;
using DiplomaProjects.DataAccess.Entities.Address;
using DiplomaProjects.Application.Services.UsersService;
using DiplomaProjects.Core.Abstractions.ServicesAbstractions.UsersAbstractions;
using DiplomaProjects.DataAccess.Entities.Users;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DiplomaDbContext>(
	options =>
	{
		options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DiplomaDbContext)),
		x => x.MigrationsAssembly("DiplomaProjects.DataAccess"));
	});

builder.Services.AddIdentityCore<User>()
	.AddEntityFrameworkStores<DiplomaDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
 {
	 options.SaveToken = true;
	 options.RequireHttpsMetadata = false;
	 options.TokenValidationParameters = new TokenValidationParameters()
	 {
		 ValidateIssuer = false,
		 ValidateAudience = false,
		 ValidateLifetime = true,
		 ValidateIssuerSigningKey = true,
		 ClockSkew = TimeSpan.Zero,
		 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:Secret"]))
	 };
 });
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IAddressServices, AddressService>();
builder.Services.AddScoped<IRepositories<CountriesEntity>, Repositories<CountriesEntity>>();
builder.Services.AddScoped<IRepositories<RegionsEntity>, Repositories<RegionsEntity>>();
builder.Services.AddScoped<IRepositories<CitiesEntity>, Repositories<CitiesEntity>>();
builder.Services.AddScoped<IRepositories<DistrictsEntity>, Repositories<DistrictsEntity>>();
builder.Services.AddScoped<IRepositories<MicroDistrictsEntity>, Repositories<MicroDistrictsEntity>>();
builder.Services.AddScoped<IRepositories<StreetDistrictsEntity>, Repositories<StreetDistrictsEntity>>();
builder.Services.AddScoped<IRepositories<StreetsEntity>, Repositories<StreetsEntity>>();
builder.Services.AddScoped<IRepositories<AddressOfHouseEntity>, Repositories<AddressOfHouseEntity>>();

builder.Services.AddScoped<IUsersInfoServices, UserInfoService>();
builder.Services.AddScoped<IRepositories<UserInfoEntity>, Repositories<UserInfoEntity>>();



builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUsersEndpoints();

app.UseCors(x =>
{
	x.AllowAnyHeader();
	x.AllowAnyOrigin();
	x.AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
