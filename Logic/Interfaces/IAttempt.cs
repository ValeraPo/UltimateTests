using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IAttempt
    {
        public AttemptDTO GetEntity(long id);
        public ObservableCollection<AttemptDTO> GetListEntity();
        public QuizzeDTO GetQuiz(AttemptDTO attempt);
        public void SaveChange();
        public void Refresh();
    }
}