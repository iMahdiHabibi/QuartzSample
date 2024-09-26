namespace QuartzSample.Job
{
	public class JobSchedule(Type jobType, string experssion)
	{
		public Type JobType { get; set; } = jobType;

		public string Experssion { get; set; } = experssion;
	}
}
