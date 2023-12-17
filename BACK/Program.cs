using FreeGamesAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Dodane
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PdfService>();


var rapidApiSettings = builder.Configuration.GetSection("RapidApi");
var freeToPlayApiSettings = builder.Configuration.GetSection("FreeToPlayApi");
var gameDetailApiSettings = builder.Configuration.GetSection("GameDetailApi");

builder.Services.AddHttpClient<IGameService, GameService>(client =>
{
    client.BaseAddress = new Uri(rapidApiSettings["BaseUri"]);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", rapidApiSettings["Host"]);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", rapidApiSettings["Key"]);
});

builder.Services.AddHttpClient<IFreeToPlayGameService, FreeToPlayGameService>(client =>
{
    client.BaseAddress = new Uri(freeToPlayApiSettings["BaseUri"]);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", freeToPlayApiSettings["Host"]);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", freeToPlayApiSettings["Key"]);
});

builder.Services.AddHttpClient<IGameDetailService, GameDetailService>(client =>
{
    client.BaseAddress = new Uri(gameDetailApiSettings["BaseUri"]);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", gameDetailApiSettings["Host"]);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", gameDetailApiSettings["Key"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers().RequireCors("AllowSpecificOrigin");

app.Run();
