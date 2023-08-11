using FluentValidation;
using MongoDB.Driver;
using SchoolXplorer.Application.Dtos;
using SchoolXplorer.Application.Mappings;
using SchoolXplorer.Application.Services;
using SchoolXplorer.Application.Validators;
using SchoolXplorer.Domain.Repositories;
using SchoolXplorer.Infrastructure.MongoData;
using SchoolXplorer.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
//Mongo Db config
var mongoDbSettingsSection = builder.Configuration.GetSection("MongoDbSettings");
builder.Services.Configure<MongoDbSettings>(mongoDbSettingsSection);

var mongoDbSettings = mongoDbSettingsSection.Get<MongoDbSettings>();
builder.Services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(mongoDbSettings.ConnectionString));

builder.Services.AddSingleton<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.DatabaseName));
builder.Services.AddScoped<ISchoolDistrictService, SchoolDistrictService>();
builder.Services.AddTransient<ISchoolDistrictRepository, SchoolDistrictRepository>();
builder.Services.AddAutoMapper(typeof(SchoolDistrictProfile));

builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<CreateSchoolDistrictDto>, CreateSchoolDistrictDtoValidator>();

var app = builder.Build();

app.MapControllers();

app.Run();
public partial class Program { };
