using BitacoraAPP.Data;
using BitacoraAPP.Services;
using BitacoraAPP.Services.ActivationServices;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUsuarioEmpleadoService,UsuarioEmpleadoService>();
builder.Services.AddTransient<IBitacoraService,BitacoraService>();
builder.Services.AddTransient<IEmailService,EmailService>();
builder.Services.AddTransient<IExcellReportService,ExcellReportService>();
builder.Services.AddTransient<IActivationGeneralReportService, ActivationGeneralReportService>();
builder.Services.AddTransient<IAssetConsultService, AssetConsultService>();
builder.Services.AddTransient<ICommon, Common>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});
builder.Services.AddAuthentication().AddCookie(options =>
{
    options.LoginPath = "/Home";
    options.LogoutPath = "/Home";
});

builder.Services.AddHangfire(z => z.SetDataCompatibilityLevel(CompatibilityLevel.Version_170).UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings().UseSqlServerStorage(connectionString, new SqlServerStorageOptions
{
    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
    QueuePollInterval = TimeSpan.Zero,
    UseRecommendedIsolationLevel = true,
    DisableGlobalLocks = true

}));

builder.Services.AddHangfireServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.UseHangfireDashboard();
RecurringJob.AddOrUpdate<IActivationGeneralReportService>("Enviando email de reporte general", servicio =>  
servicio.ActivateGeneralReportService(), Cron.Weekly(DayOfWeek.Wednesday,8));               
RecurringJob.AddOrUpdate<IBitacoraService>("Se inicio el corte de la Bitacora", servicio => 
servicio.InsertCorteBitacoraService(), Cron.Daily(22));
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


