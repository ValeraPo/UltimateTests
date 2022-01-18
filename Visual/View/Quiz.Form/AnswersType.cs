using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.View.Quiz.Form
{
    internal class AnswersType
    {
        public int TypeInt { get; set; }
        public string TypeString { get; set; }
        public AnswersType(int typeInt, string typeString)
        {
            TypeInt = typeInt;
            TypeString = typeString;
        }
        //public override string ToString()
        //{
        //    return TypeString;
        //}
    }
}
