using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.Model
{
    internal class AppointmentModel : INotifyPropertyChanged
    {
        #region Implement INotyfyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
        
        #region Fields

        private string _date;

        #endregion

        #region Properties

        public string Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        #endregion
    }
}
