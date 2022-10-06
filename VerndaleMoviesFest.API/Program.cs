using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using VerndaleMoviesFest.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //

// Database ConnectionString
builder.Services.AddEntityFrameworkMySQL().AddDbContext<DBContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
