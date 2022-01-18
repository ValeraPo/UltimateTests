using System.Collections.ObjectModel;
using Data.Interfaces;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class Attempt : IAttempt
    {
        private IRepository<Data.Maps.Attempt> _attempts;

        public Attempt()
        {
            _attempts = IocKernel.Get<IRepository<Data.Maps.Attempt>>();
        }
        public AttemptDTO GetEntity(long id)
        {
            return new AttemptDTO(_attempts.GetEntity(id));
        }
        public ObservableCollection<AttemptDTO> GetListEntity()
        {
            var attempts = new ObservableCollection<AttemptDTO>();
            foreach (var attempt in _attempts.GetListEntity())
                attempts.Add(new AttemptDTO(attempt));

            return attempts;
        }
        // Quiz по назначению
        public QuizzeDTO GetQuiz(AttemptDTO attempt)
        {
            var tmp = _attempts.GetEntity(attempt.Id);
            return new QuizzeDTO(tmp.Quizze);
        }
        // Сохранить изменения
        public void SaveChange() => _attempts.Save();
        // Обновление модели (пересоздании зависимостей EF)
        public void Refresh() => _attempts.Refresh();
    }
}