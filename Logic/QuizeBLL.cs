using System.Collections.Generic;
using System.Drawing;
using System;
using Logic.Interfaces;


namespace Logic
{
    public class QuizeBLL : IQuize
    {
        // Класс для вопроса
        public class Question : IQuestion
        {
            // Конструкторы
            public Question(string quest)
            {
                Quest = quest;
                Answers = new List<(string, bool)>();
            }

            public Question(string quest, List<(string, bool)> answers) : this(quest)
            {
                Answers = answers;
            }
            
            private string _quest;
            private List<(string, bool)> _answers;
            public long ID { get; set; }

            public string Quest
            {
                get => _quest;
                set
                {
                    IsEmpty(value);
                    if (value.Length > 280)
                        throw new ArgumentOutOfRangeException("Максимум 280 символов");
                    _quest = value;
                }
            }
            public List<(string, bool)> Answers
            {
                get => _answers;
                set
                {
                    IsEmpty(value);
                    _answers = value;
                }
            }
            
            // добавить вариант ответа
            public void AddAnswer((string, bool) answer)
            {
                IsEmpty(answer.Item1);
                IsEmpty(answer.Item2);
                Answers.Add(answer);
            }

            private static void IsEmpty(object obj)
            {
                if (obj == null)
                    throw new ArgumentNullException("Объект не может быть пустым");
            }
        }
        public QuizeBLL(List<IQuestion> test, int scores)
        {
            Test = test;
            Scores = scores;
        }
        public long ID { get; set; }

        public List<IQuestion> Test { get; set; }
        public int Scores { get; set; } // Максимальные баллы за прохождение
        public List<string> Tegs { get; set; }

        // Добавить вопрос
        public void AddQuestion(string textQuestion)
        {
            Question question = new Question(textQuestion);
            Test.Add(question);
        }
        public void AddQuestion(string textQuestion, List<(string, bool)> answers)
        {
            Question question = new Question(textQuestion, answers);
            Test.Add(question);
        }
        
        // Проверка правильности ответа
        public bool CheckAnswer(string question, string answer)
        {
            foreach (var quest in Test)
                if (quest.Quest == question)
                    foreach (var answ in quest.Answers)
                        if (answ.Item1 == answer)
                        {
                            if (answ.Item2 == true) return true;
                            return false;
                        }
            return false; // без этой строчки не компилируется, хотя сюда мы никогда не попадем
        }
        
        
    }

    
}