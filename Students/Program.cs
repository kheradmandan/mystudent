using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using Students.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentDbContext>(opt =>
{
    opt.UseSqlServer("Server=DESKTOP-POCSAAB\\SQL;Database=Student_Core19;Trusted_Connection=True;");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option=>
    {
        option.LoginPath = "/User/Login";
        option.LogoutPath = "/User/LogOut";
        option.ExpireTimeSpan=TimeSpan.FromDays(10);
    });
builder.Services.AddScoped<ITeacher, TeacherRepository>();
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<ICourse, CourseRepository>();
builder.Services.AddScoped<ICourseStudent, CourseStudentRepository>();
builder.Services.AddScoped<ICI_Role, CI_RoleRepository>();
builder.Services.AddScoped<ICI_FieldCourse, CI_FieldCourseRepository>();
builder.Services.AddScoped<ICI_FieldStudent, CI_FieldStudentRepository>();
builder.Services.AddScoped<IUser, UserRepository>();




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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
