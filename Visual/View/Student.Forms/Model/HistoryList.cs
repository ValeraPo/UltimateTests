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
    }
}
