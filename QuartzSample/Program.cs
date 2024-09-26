using Cart_Exam.Jobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzSample.Data;
using QuartzSample.Job;

namespace QuartzSample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Context") ?? throw new InvalidOperationException("Connection string 'Context' not found.")));
      

		builder.Services.AddSingleton<IJobFactory, MyJobFactory>();
		builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

		builder.Services.AddSingleton<MyJob>();

		builder.Services.AddSingleton(new JobSchedule(typeof(MyJob),
			"0/5 * * * * ?"
		));


		builder.Services.AddSingleton<AddToDbJob>();

		builder.Services.AddSingleton(new JobSchedule(typeof(AddToDbJob),
			"0/10 * * * * ?"
		));

		builder.Services.AddHostedService<QuartzHostedService>();


		// Add services to the container.
		builder.Services.AddControllersWithViews();

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
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
