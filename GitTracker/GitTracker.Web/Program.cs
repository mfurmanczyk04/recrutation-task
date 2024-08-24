using GitTracker.Core.Interfaces;
using GitTracker.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GitHubService>(x =>
{
    var httpClient = new HttpClient();
    return new GitHubService(httpClient);
});
builder.Services.AddScoped<GitLabService>(x =>
{
    var httpClient = new HttpClient();
    return new GitLabService(httpClient);
});

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
