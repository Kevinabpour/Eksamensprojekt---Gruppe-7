using Eksamensprojekt___Gruppe_7.Repositories;
using Eksamensprojekt___Gruppe_7.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAnimalRepo, AnimalRepo>();
builder.Services.AddSingleton<AnimalService>();
builder.Services.AddSingleton<IEventRepo, EventRepo>();
builder.Services.AddSingleton<EventService>();
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