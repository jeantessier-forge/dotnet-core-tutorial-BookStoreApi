using BookStoreApi.Models;
using BookStoreApi.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection(BookStoreDatabaseSettings.SectionName));

var mongoConnectionString = builder.Configuration[BookStoreDatabaseSettings.SectionName + ":ConnectionString"];
builder.Services.AddSingleton<MongoClient>(sp => new MongoClient(mongoConnectionString));

builder.Services.AddScoped<BooksService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMyDependency, MyDependency2>();

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
