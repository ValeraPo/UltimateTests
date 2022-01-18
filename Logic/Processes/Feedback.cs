using System.Collections.ObjectModel;
using System.Linq;
using Data.Interfaces;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class Feedback : IFeedback
    {
        private IRepository<Data.Maps.Feedback> _feedbacks;

        public Feedback()
        {
            _feedbacks = IocKernel.Get<IRepository<Data.Maps.Feedback>>();
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
        public void RemoveFeedback(string text)
        {
            _feedbacks.Delete(_feedbacks.GetListEntity().Single(t=> t.Text == text).ID_Feedback);
        }
        // Сохранить изменения
        public void SaveChange() => _feedbacks.Save();
        // Обновление модели (пересоздании зависимостей EF)
        public void Refresh() => _feedbacks.Refresh();
    }
}