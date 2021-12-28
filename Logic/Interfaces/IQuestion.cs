using System.Collections.Generic;

namespace Logic.Interfaces
{
	public interface IQuestion
	{
		public string Quest { get; set; }
		public List<(string, bool)> Answers { get; set; }
		public long ID { get; set; }
		public void AddAnswer((string, bool) answer);
	}
}
