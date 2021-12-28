using System.Collections.Generic;
using System.Linq;
using Data.Maps;

namespace Logic
{
    public static class Searching
    {
        // Поиск по тегу тестов
        public static IEnumerable<Quizze> SearchQuizzeByTeg(SetTag teg)
        {
            return teg.QuizzesCategories.Select(t => t.Quizze).Where(t => !t.IsDel);
        }

        // Поиск по тегу групп
        public static IEnumerable<Group> SearchGroupByTeg(SetTag teg)
        {
            return teg.GroupsCategories.Select(t => t.Group).Where(t => !t.IsDel);
        }
    }
}