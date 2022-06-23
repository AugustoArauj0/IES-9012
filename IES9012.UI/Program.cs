using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IES9012.UI.Data;
var builder = WebApplication.CreateBuilder(args);

//Inyeccion de dependencias, se instancia un objeto (IES9012Context) para cada usuario (con vida util corta donde, se crea el objeto, se usa y luego se destruye) en vez de un objeto para el programa
builder.Services.AddRazorPages();
builder.Services.AddDbContext<IES9012Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IES9012Context") ?? throw new InvalidOperationException("Connection string 'IES9012Context' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<IES9012Context>();
    context.Database.EnsureCreated();  //El metodo EnsureCreated() crea una base de datos para ambito de desarrollo que no guarda permanentemente los datos ingresados
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
