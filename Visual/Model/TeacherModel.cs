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
        #region ctor
        public TeacherModel() { }
        public TeacherModel(ObservableCollection<string> groups) : base()
        {
            _groups = groups;
        }


        #endregion
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
