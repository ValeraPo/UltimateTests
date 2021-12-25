using System.Collections.Generic;

namespace Logic.Interfaces
{
	public interface IQuize
	{
        public long ID { get; set; }
        public List<IQuestion> Test { get; set; }
        public int Scores { get; set; }
        public List<string> Tegs { get; set; }


        public void AddQuestion(string textQuestion);
        public void AddQuestion(string textQuestion, List<(string, bool)> answers);
        public bool CheckAnswer(string question, string answer);

	}
}
