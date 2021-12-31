using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTrying.View.Student.Model
{
    internal class HistoryList
    {
        private string _quiz;
        private string _teacher;
        private string _score;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Quiz
        {
            get { return _quiz; }
            set { _quiz = value; }
        }
        public string Teacher
        {
            get { return _teacher; }
            set { _teacher = value; }
        }
        public string Score
        {
            get { return _score; }
            set { _score = value; }
        }
    }
}
