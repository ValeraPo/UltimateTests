using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Data.Interfaces;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class SetTag : ISetTag
    {
        private IRepository<Data.Maps.SetTag> _tags;
        public SetTag(IRepository<Data.Maps.SetTag> tags)
        {
            _tags = tags;
        }


        public SetTagDTO GetEntity(long id)
        {
            return new SetTagDTO(_tags.GetEntity(id));
        }
        public ObservableCollection<SetTagDTO> GetListEntity()
        {
            var tags = new ObservableCollection<SetTagDTO>();
            foreach (var teg in _tags.GetListEntity()) { tags.Add(new SetTagDTO(teg)); }

            return tags;
        }


        // Поиск по тегу групп
        public ObservableCollection<GroupDTO> SearchGroupByTeg(ObservableCollection<SetTagDTO> tags)
        {
            if (tags == null || !tags.Any())
                throw new ArgumentNullException(nameof(tags), "Пустой список");
            var mapsTags   = tags.Select(g => _tags.GetEntity(g.Id)).ToList();
            var groupByTeg = new ObservableCollection<GroupDTO>();
            foreach (var g in mapsTags.SelectMany(t => t.GroupsCategories.Select(s => s.Group)))
            {
                var tmp = new GroupDTO(g);
                if (!groupByTeg.Contains(tmp))
                    groupByTeg.Add(tmp);
            }

            return groupByTeg;
        }
        public ObservableCollection<QuizzeDTO> SearchQuizzesByTeg(ObservableCollection<SetTagDTO> tags)
        {
            if (tags == null || !tags.Any())
                throw new ArgumentNullException(nameof(tags), "Пустой список");
            var mapsTags     = tags.Select(g => _tags.GetEntity(g.Id)).ToList();
            var quizzesByTeg = new ObservableCollection<QuizzeDTO>();
            foreach (var g in mapsTags.SelectMany(t => t.QuizzesCategories.Select(s => s.Quizze)))
            {
                var tmp = new QuizzeDTO(g, false);
                if (!quizzesByTeg.Contains(tmp))
                    quizzesByTeg.Add(tmp);
            }

            return quizzesByTeg;
        }
        // Удаление тега
        public void RemoveTeg(SetTagDTO teg)
        {
            _tags.Delete(teg.Id);
        }
        // Сохранить изменения
        public void SaveChange() => _tags.Save();
        //Сохранение изменения
        public void Update(SetTagDTO teg)
        {
            var tmp = _tags.GetEntity(teg.Id);
            tmp.Text  = teg.Text;
            _tags.Update(tmp);

            SaveChange();
        }
    }
}