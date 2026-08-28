using CharacterCreator.Api.Interfaces;
using CharacterCreator.Api.Services;
using CharacterCreator.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var sqlite = new SqliteConnectionStringBuilder(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Missing connection string 'DefaultConnection'."));
sqlite.DataSource = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, sqlite.DataSource));

builder.Services.AddDbContext<CharacterDbContext>(options =>
    options.UseSqlite(sqlite.ConnectionString));
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ISpeciesService, SpeciesService>();
builder.Services.AddScoped<ICharacterClassService, CharacterClassService>();
builder.Services.AddScoped<IBackgroundService, CharacterCreator.Api.Services.BackgroundService>();
builder.Services.AddScoped<ISetupService, SetupService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
        policy.WithOrigins(
                "https://localhost:7113",
                "http://localhost:5164")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CharacterDbContext>();
    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("BlazorClient");
app.UseAuthorization();
app.MapControllers();
app.Run();
