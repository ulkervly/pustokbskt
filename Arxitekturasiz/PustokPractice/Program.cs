using Microsoft.EntityFrameworkCore;
using Pustok.Business.Services.Implementations;
using Pustok.Business.Services.Interfaces;
using Pustok.Data.Repositories.Implementations;
using Pustok.Repositories.Interfaces;
using PustokPractice.Business.Services.Implementations;
using PustokPractice.DAL;
//using PustokPractice.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAuhtorService, AuhtorService>();
builder.Services.AddScoped<IBookService, BookService>();
//builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IBookTagsRepository, BookTagRepository>();
builder.Services.AddScoped<IBookImagesRepository, BookImagesRepository>();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(20);
});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=LAPTOP-N2MJ83JU\\SQLEXPRESS;Database=Pustoknew2;Trusted_Connection=True");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
