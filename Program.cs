using Eksamensgruppe_7___ClassLibrary.Repositories;
using Eksamensgruppe_7___ClassLibrary.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AnimalService>();
builder.Services.AddSingleton<IAnimalRepo, AnimalRepo>();
builder.Services.AddSingleton<AnimalService>();
builder.Services.AddSingleton<IEventRepo, EventRepo>();
builder.Services.AddSingleton<BookingRepo>();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();