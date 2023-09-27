using Challenge.Data;
using Microsoft.EntityFrameworkCore;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotEnv.Load();
builder.Services.AddDbContext<ChallengeContext>(options =>
        options.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsProduction()) app.Run("http://*:5172"); 
else app.Run();

