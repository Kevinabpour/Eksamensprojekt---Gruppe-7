using Eksamensprojekt___Gruppe_7.Repositories;
using Eksamensprojekt___Gruppe_7.Service;

var builder = WebApplication.CreateBuilder(args);

// 1) Register your IAnimalRepo and AnimalService here:
builder.Services.AddSingleton<IAnimalRepo, AnimalRepo>();
builder.Services.AddSingleton<AnimalService>();

// 2) Now add the Razor-Pages framework:
builder.Services.AddRazorPages();

var app = builder.Build();

// 3) Configure the HTTP pipeline:
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