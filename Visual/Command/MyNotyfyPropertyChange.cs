using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Command
{
    public class MyNotyfyPropertyChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var expression = property.Body as MemberExpression;
                if (expression == null)
                {
                    throw new NotSupportedException("Invalid expression passed. Only property member should be selected.");
                }

                handler(this, new PropertyChangedEventArgs(expression.Member.Name));
            }
        }

    }
}
