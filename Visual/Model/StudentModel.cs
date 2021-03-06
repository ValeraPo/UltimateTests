using System.Collections.ObjectModel;

namespace Visual.Model
{
    internal class StudentModel : UserModel
    {

        #region ctor

        public StudentModel() { }
        public StudentModel(string group) : base()
        {
            _group = group;
        }

        #endregion


        private string                                 _group;
        private ObservableCollection<AppointmentModel> _appointment;
        public ObservableCollection<AppointmentModel> Appointments
        {
            get { return _appointment; }
            set
            { _appointment = value;
              OnPropertyChanged("Appointments"); }
        }
        public string Group
        {
            get { return _group; }
            set
            { if (_group != value)
            {
                _group = value;
                OnPropertyChanged("Group");
            } }
        }
    }
}