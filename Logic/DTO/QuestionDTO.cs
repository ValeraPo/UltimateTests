using System.Collections.ObjectModel;
using System.Linq;

namespace Logic.DTO
{
    public class QuestionDTO : AbstractOnPropertyChanged
    {
        private int                             _idQuestType;
        private string                          _text;
        private ObservableCollection<AnswerDTO> _answers;
        
        
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
            : this(text, idQuestType, new ObservableCollection<AnswerDTO>()) { }
        public QuestionDTO(Data.Maps.Question question)
        {
            Id           = question.ID_Quest;
            ID_QuestType = question.ID_QuestType;
            Text         = question.Text;
            Answers      = new ObservableCollection<AnswerDTO>();
            foreach (var answer in question.Answers.Where(t => !t.IsDel))
                Answers.Add(new AnswerDTO(answer));
        }


        public long Id {get; set;}
        public int ID_QuestType
        {
            get => _idQuestType;
            set
            { if (_idQuestType == value)
                  return;
              _idQuestType = value;
              OnPropertyChanged(nameof(ID_QuestType)); }
        }
        public string Text
        {
            get => _text;
            set
            { if (_text == value)
                  return;
              _text = value;
              OnPropertyChanged(nameof(Text)); }
        }
        public ObservableCollection<AnswerDTO> Answers
        {
            get => _answers;
            set
            { if (_answers == value)
                  return;
              _answers = value;
              OnPropertyChanged(nameof(Answers)); }
        }
    }
}