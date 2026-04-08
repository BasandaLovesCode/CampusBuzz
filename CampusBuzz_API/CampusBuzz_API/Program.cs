using CampusBuzz_API.Data;
using CampusBuzz_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adds support for MVC controllers (handles HTTP requests like GET, POST, etc.)
builder.Services.AddControllers();


//configures it to use SQL Server with the connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// This allows your controllers/services to use IEventRepository without manually creating it
builder.Services.AddScoped<IEventRepository, EventRepository>();

// Adds support for API endpoint discovery (used by Swagger)
// Helps tools understand what endpoints exist in your API
builder.Services.AddEndpointsApiExplorer();

// Registers Swagger services to generate API documentation
// Swagger provides a UI to test your API endpoints in the browser
builder.Services.AddSwaggerGen();

/* 
 Core Origin Resource Sharing:

-Allows front end and backend to talk to each other.
-Same Origin means A frontend can only call an API if they come from the same origin (same domain, port, protocol).
-Allows requests from any origin by using CORS.
 
 */
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")// Only Angular can talk to this API,more secure.
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable Swagger ONLY in development (for testing API in browser)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Forces all requests to use HTTPS (security best practice)
app.UseHttpsRedirection();

// Enables communication between Angular (port 4200) and this API
app.UseCors("AngularApp");

// Handles authorization (who is allowed to access what)
app.UseAuthorization();

// Maps incoming HTTP requests
app.MapControllers();

// Starts the application
app.Run();