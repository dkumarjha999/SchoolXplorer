using FluentValidation;
using SchoolExplorer.Application.Mappings;
using SchoolExplorer.Application.Services;
using SchoolExplorer.Application.Validators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ISchoolDistrictService, SchoolDistrictService>();
builder.Services.AddAutoMapper(typeof(SchoolDistrictProfile));

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateSchoolDistrictDtoValidator));

var app = builder.Build();

app.MapControllers();

app.Run();
public partial class Program { };
