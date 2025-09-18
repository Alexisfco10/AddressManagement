using Application;
using Asp.Versioning;
using Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

//Add DbContext
builder.Services.AddContext(builder.Configuration);

//Add Repository
builder.Services.AddRepositories();

//Add UnitOfWork
builder.Services.AddUnitOfWork();
  
//Add Mappers
builder.Services.AddMappers();

//Add Services
builder.Services.AddServices();

//Add Validators
builder.Services.AddValidators();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
