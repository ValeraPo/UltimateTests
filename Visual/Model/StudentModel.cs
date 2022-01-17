using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Model
{
    internal class StudentModel:UserModel
    {

        private string _group;
        private ObservableCollection<AppointmentModel> _appointment;
        public ObservableCollection<AppointmentModel> Appointments
        {
            get { return _appointment; }
            set
            {
                _appointment = value;
                OnPropertyChanged("Appointments");
            }
        }
        public string Group
        {
            get { return _group; }
            set
            {
                if (_group != value)
                {
                    _group = value;
                    OnPropertyChanged("Group");
                }
            }
        }
    }
}
