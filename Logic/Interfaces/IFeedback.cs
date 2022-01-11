using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IFeedback
    {
        public FeedbackDTO GetEntity(long id);
        public ObservableCollection<FeedbackDTO> GetListEntity();
        public void RemoveFeedback(FeedbackDTO feedback);
        public void RemoveFeedback(string text);
        public void SaveChange();
    }
}