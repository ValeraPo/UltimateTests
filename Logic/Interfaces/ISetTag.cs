using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface ISetTag
    {
        public SetTagDTO GetEntity(long id);
        public SetTagDTO GetEntity(string text);
        public ObservableCollection<SetTagDTO> GetListEntity();
        public ObservableCollection<GroupDTO> SearchGroupByTeg(IEnumerable<SetTagDTO> tags);
        public ObservableCollection<QuizzeDTO> SearchQuizzesByTeg(IEnumerable<SetTagDTO> tags);
        public void AddTeg(string text);
        public void RemoveTeg(SetTagDTO teg);
        public void RemoveTeg(string text);
        public void SaveChange();
        public void Refresh();
        public void Update(SetTagDTO teg);
    }
}