using System.Collections.ObjectModel;
using Data.Interfaces;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class Attempt : IAttempt
    {
        private IRepository<Data.Maps.Attempt> _attempts;

        public Attempt(IRepository<Data.Maps.Attempt> attempts)
        {
            _attempts = attempts;
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
        // Сохранить изменения
        public void SaveChange() => _attempts.Save();
    }
}