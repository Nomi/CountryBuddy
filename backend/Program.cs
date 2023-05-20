using GraphQL.Client.Http;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Serializer.Newtonsoft;
using backend.DataRepositories;



//Starting the building process.
var builder = WebApplication.CreateBuilder(args);

//For reading appsettings.
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(config["GraphQLURI"], new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
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

if(config.GetValue<bool>("EnableHttpsRedirection", true))
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.UseRouting();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
