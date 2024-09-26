using System.Globalization;
using Quartz;
using QuartzSample.Data;
using QuartzSample.Models;

namespace QuartzSample.Job
{
	public class MyJob : IJob
	{
		public async Task Execute(IJobExecutionContext context)
		{
			Console.WriteLine("Hello onother !");
			return;
		}
	}
}
