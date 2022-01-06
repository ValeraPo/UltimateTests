namespace Logic.DTO
{
    public class AnswerDTO
    {
        public AnswerDTO(long id, string text, bool isCorrect)
        {
            Id        = id;
            Text      = text;
            IsCorrect = isCorrect;
        }
        public AnswerDTO(string text, bool isCorrect)
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
        public long   Id        {get; set;}
        public string Text      {get; set;}
        public bool   IsCorrect {get; set;}
    }
}