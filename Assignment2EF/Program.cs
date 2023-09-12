using Assignment2EF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//calling service
builder.Services.AddMvc();
//registering service
builder.Services.AddDbContext<WA_Context>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DBStr"]));

builder.Services.AddScoped<IWorkshopRepo, WorkshopRepo>();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

app.UseStaticFiles(); //for css
app.UseRouting();

app.UseEndpoints(endpoints =>
    { endpoints.MapDefaultControllerRoute(); });

app.Run();
