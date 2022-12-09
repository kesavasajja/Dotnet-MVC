var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// builder.Services.AddCors((setup) =>
// {
//     setup.AddPolicy("default", (options) =>
//     {
//         options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
//     });
// });

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            

        app.UseHttpsRedirection(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




// app.Use(async(context,next)=>{
//     context.Response.Headers.Add("Access-Control-Allow-Credentials",new[]{"true"});
// });
// app.UseCors("default");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
