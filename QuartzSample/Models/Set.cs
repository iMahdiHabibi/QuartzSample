using System.ComponentModel.DataAnnotations;

namespace QuartzSample.Models
{
	public class Set
	{
		public Set(string k)
		{
			K = k;
		}

		[Key]
		public string K { get; set; }


		public string V { get; set; } = Guid.NewGuid().ToString();
		
	}
}
