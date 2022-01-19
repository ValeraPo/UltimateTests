using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Data.Interfaces;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class SetTag : ISetTag
    {
        private readonly IRepository<Data.Maps.SetTag> _tags;
        private readonly IRepository<Data.Maps.Quizze> _quizzes;
        private readonly IRepository<Data.Maps.Group>  _grops;
        public SetTag()
        {
            _tags    = IocKernel.Get<IRepository<Data.Maps.SetTag>>();
            _quizzes = IocKernel.Get<IRepository<Data.Maps.Quizze>>();
            _grops   = IocKernel.Get<IRepository<Data.Maps.Group>>();
        }


        public SetTagDTO GetEntity(long id)
        {
            return new SetTagDTO(_tags.GetEntity(id));
        }
        public SetTagDTO GetEntity(string text)
        {
            return new SetTagDTO(_tags.GetListEntity().Single(t => t.Text == text));
        }
        public ObservableCollection<SetTagDTO> GetListEntity()
        {
            var tags = new ObservableCollection<SetTagDTO>();
            foreach (var teg in _tags.GetListEntity())
                tags.Add(new SetTagDTO(teg));

            return tags;
        }


        // Поиск по тегу групп
        public ObservableCollection<GroupDTO> SearchGroupByTeg(IEnumerable<SetTagDTO> tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags), "Пустой список");
            var groupByTeg = new ObservableCollection<GroupDTO>();
            if (!tags.Any())
            {
                foreach (var group in _grops.GetListEntity())
                    groupByTeg.Add(new GroupDTO(group));
                return groupByTeg;
            }
            var mapsTags = tags.Select(g => _tags.GetEntity(g.Id)).ToList();
            foreach (var g in mapsTags.SelectMany(t => t.GroupsCategories.Select(s => s.Group)))
            {
                var tmp = new GroupDTO(g);
                if (!groupByTeg.Contains(tmp))
                    groupByTeg.Add(tmp);
            }

            return groupByTeg;
        }
        // Поиск по тегу Qiuz
        public ObservableCollection<QuizzeDTO> SearchQuizzesByTeg(IEnumerable<SetTagDTO> tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags), "Пустой список");
            var quizzesByTeg = new ObservableCollection<QuizzeDTO>();
            if (!tags.Any())
            {
                foreach (var quiz in _quizzes.GetListEntity())
                    quizzesByTeg.Add(new QuizzeDTO(quiz));
                return quizzesByTeg;
            }
            var mapsTags = tags.Select(g => _tags.GetEntity(g.Id)).ToList();
            foreach (var g in mapsTags.SelectMany(t => t.QuizzesCategories.Select(s => s.Quizze)))
            {
                var tmp = new QuizzeDTO(g);
                if (!quizzesByTeg.Contains(tmp))
                    quizzesByTeg.Add(tmp);
            }

            return quizzesByTeg;
        }
        // Создание(добавление) тега
        public void AddTeg(string text)
        {
            if (_tags.GetListEntity()
                     .Select(t => t.Text)
                     .Contains(text))
                throw new ArgumentException("Такой тег уже существует");
            _tags.Create(new Data.Maps.SetTag
                         {
                             Text = text
                         });
            SaveChange();
        }
        // Удаление тега
        public void RemoveTeg(SetTagDTO teg)
        {
            _tags.Delete(teg.Id);
        }
        public void RemoveTeg(string text)
        {
            _tags.Delete(_tags.GetListEntity().Single(t => t.Text == text).ID_TagSet);
        }
        // Сохранить изменения
        public void SaveChange() => _tags.Save();
        // Обновление модели (пересоздании зависимостей EF)
        public void Refresh() => _tags.Refresh();
        // Сохранение изменения
        public void Update(SetTagDTO teg)
        {
            var tmp = _tags.GetEntity(teg.Id);
            if (_tags.GetListEntity()
                     .Select(t => t.Text)
                     .Contains(teg.Text))
                throw new ArgumentException("Такой тег уже существует");
            tmp.Text = teg.Text;
            _tags.Update(tmp);

            SaveChange();
        }
    }
}