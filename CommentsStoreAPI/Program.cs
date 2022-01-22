using CommentsStoreAPI.Models;
using CommentsStoreAPI.Services;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CommentStoreDBSettings>(
    builder.Configuration.GetSection("CommentStoreDb"));
builder.Services.AddSingleton<CommentsService>();


builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
