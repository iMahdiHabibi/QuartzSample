using System.Globalization;
using Quartz;
using QuartzSample.Data;
using QuartzSample.Models;

namespace QuartzSample.Job
{
	public class AddToDbJob(IServiceProvider service):IJob
	{
		public async Task Execute(IJobExecutionContext context)
		{
			await using var s = service.CreateAsyncScope();
			var db = s.ServiceProvider.GetService(typeof(Context)) as Context;
			await db.Set.AddAsync(new Set(DateTime.Now.ToString(CultureInfo.CurrentCulture)));
			await db.SaveChangesAsync();
		}
	}
}
