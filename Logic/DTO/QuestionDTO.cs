using System.Collections.ObjectModel;
using System.Linq;

namespace Logic.DTO
{
    public class QuestionDTO
    {
        public QuestionDTO(long id, int idQuestType, string text, ObservableCollection<AnswerDTO> answers)
        {
            Id           = id;
            ID_QuestType = idQuestType;
            Text         = text;
            Answers      = answers;
        }
        public QuestionDTO(string text, int idQuestType, ObservableCollection<AnswerDTO> answers)
        {
            ID_QuestType = idQuestType;
            Text         = text;
            Answers      = answers;
        }
        public QuestionDTO(string text, int idQuestType = 1) 
            : this(text, idQuestType, new ObservableCollection<AnswerDTO>()){ }
        public QuestionDTO(Data.Maps.Question question)
        {
            Id           = question.ID_Quest;
            ID_QuestType = question.ID_QuestType;
            Text         = question.Text;
            Answers      = new ObservableCollection<AnswerDTO>();
            foreach (var answer in question.Answers.Where(t => !t.IsDel))
                Answers.Add(new AnswerDTO(answer));
        }
        
        
        public long                            Id           {get; set;}
        public int                             ID_QuestType {get; set;}
        public string                          Text         {get; set;}
        public ObservableCollection<AnswerDTO> Answers      {get; set;}
    }
}