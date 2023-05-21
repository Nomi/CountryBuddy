using GraphQL.Client.Http;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Serializer.Newtonsoft;
using backend.DataRepositories;



// Starting the building process.
var builder = WebApplication.CreateBuilder(args);

// For reading the configuration.
var config = builder.Configuration;

// Add services to the container. (Needed for Dependancy Injection)
builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(config["GraphQLURI"], new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (config.GetValue<bool>("EnableHttpsRedirection", true))
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.UseRouting();

// Adjusting Cors related options.
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Controllers and Endpoints.
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Running the application.
app.Run();
