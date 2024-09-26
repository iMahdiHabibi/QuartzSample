using Quartz;
using Quartz.Spi;

namespace QuartzSample.Job
{
	public class MyJobFactory(IServiceProvider serviceProvider):IJobFactory
	{
		public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
		{
			var model = (serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob)!;
			return model;
		}

		public void ReturnJob(IJob job)
		{
			
		}
	}
}
