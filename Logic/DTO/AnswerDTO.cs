namespace Logic.DTO
{
    public class AnswerDTO : AbstractOnPropertyChanged
    {
        private string _text;
        private bool   _isCorrect;
        

        public AnswerDTO(long id, string text, bool isCorrect)
        {
            Id        = id;
            Text      = text;
            IsCorrect = isCorrect;
        }
        public AnswerDTO(string text, bool isCorrect = false)
        {
            Text      = text;
            IsCorrect = isCorrect;
        }
        public AnswerDTO(Data.Maps.Answer answer)
        {
            Id        = answer.ID_Answ;
            Text      = answer.Text;
            IsCorrect = answer.IsCorrect;
        }
        public long Id {get; set;}
        public string Text
        {
            get => _text;
            set
            { if (_text == value)
                  return;
              _text = value;
              OnPropertyChanged(nameof(Text)); }
        }
        public bool IsCorrect
        {
            get => _isCorrect;
            set
            { if (_isCorrect == value)
                  return;
              _isCorrect = value;
              OnPropertyChanged(nameof(IsCorrect)); }
        }
    }
}