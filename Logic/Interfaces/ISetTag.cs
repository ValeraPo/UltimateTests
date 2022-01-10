using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface ISetTag
    {
        public SetTagDTO GetEntity(long id);
        public ObservableCollection<SetTagDTO> GetListEntity();
        public ObservableCollection<GroupDTO> SearchGroupByTeg(ObservableCollection<SetTagDTO> tags);
        public ObservableCollection<QuizzeDTO> SearchQuizzesByTeg(ObservableCollection<SetTagDTO> tags);
        public void AddTeg(string text);
        public void RemoveTeg(SetTagDTO teg);
        public void SaveChange();
        public void Update(SetTagDTO teg);
    }
}