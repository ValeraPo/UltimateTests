using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.View.Quiz.Form
{
    internal class ClassForTitle
    {
        private int _currentIndex;

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { _currentIndex = value; }
        }

        int _amountOfIndex;
        public int AmountOfIndex
        {
            get { return _amountOfIndex; }
            set { _amountOfIndex = value; }
        }
        public ClassForTitle()
        {
            //CurrentIndex = CurrentQuizze.Questions.IndexOf(CurrentQuestion);
        }
    }
    
}
