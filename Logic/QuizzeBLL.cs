using System.Collections.Generic;
using System.Drawing;
using System;
using Data.Maps;


namespace Logic
{
    public static class QuizzeBLL
    {
        // Проверка правильности ответа
        public static void CheckAnswer(Answer answer, Attempt attempt, Quizze quizze)
        {
            if (answer.IsCorrect)
                attempt.Score += quizze.MaxPoints / quizze.Questions.Count;
        }
    }
}