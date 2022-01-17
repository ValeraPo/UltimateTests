using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Model
{
    internal class TeacherModel : UserModel
    {
        private ObservableCollection<string> _groups;
        public ObservableCollection<string> Groups
        {
            get { return _groups; }
            set
            {
                if (_groups != value)
                {
                    _groups = value;
                    OnPropertyChanged("Groups");
                }
            }
        }
    }
}
