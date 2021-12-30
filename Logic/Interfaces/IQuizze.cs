using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IQuizze
    {
        public QuizzeDTO GetEntity(long id);
        public ObservableCollection<QuizzeDTO> GetListEntity();
    }
}