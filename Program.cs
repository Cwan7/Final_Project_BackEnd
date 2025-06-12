var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //to get controller support
builder.Services.AddHttpClient(); //to handle HTTP request

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://44.201.225.161:3001", "http://localhost:5173") // 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// app.UseHttpsRedirection();
app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();

