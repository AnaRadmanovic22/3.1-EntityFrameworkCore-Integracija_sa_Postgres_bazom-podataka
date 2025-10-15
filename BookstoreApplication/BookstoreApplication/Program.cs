using System;
using BookstoreApplication.Data;
using BookstoreApplication.Mapping;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookstoreContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthorsRepository>();
builder.Services.AddScoped<PublishersRepository>();
builder.Services.AddScoped<BooksRepository>();
builder.Services.AddScoped<AwardsRepository>();

builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddScoped<IAuthorsService, AuthorsService>();

builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IBooksService, BooksService>();

builder.Services.AddScoped<IPublishersRepository, PublishersRepository>();
builder.Services.AddScoped<IPublishersService, PublishersService>();

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<BookProfile>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
