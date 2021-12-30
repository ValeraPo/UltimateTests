using System;
using System.Collections.ObjectModel;
using Data.Interfaces;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class Feedback : IFeedback
    {
        private IRepository<Data.Maps.Feedback> _feedbacks;

        public Feedback(IRepository<Data.Maps.Feedback> feedbacks)
        {
            _feedbacks = feedbacks;
        }


        public FeedbackDTO GetEntity(long id)
        {
            return new FeedbackDTO(_feedbacks.GetEntity(id));
        }
        public ObservableCollection<FeedbackDTO> GetListEntity()
        {
            var feedbacks = new ObservableCollection<FeedbackDTO>();
            foreach (var feedback in _feedbacks.GetListEntity())
                feedbacks.Add(new FeedbackDTO(feedback));

            return feedbacks;
        }
        // Удаление фидбеков
        public void RemoveFeedback(FeedbackDTO feedback)
        {
            _feedbacks.Delete(feedback.Id);
        }
        // Сохранить изменения
        public void SaveChange() => _feedbacks.Save();
    }
}