using System.ComponentModel;

namespace Visual.Model
{
    internal class UserModel : INotifyPropertyChanged
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

        #region

        public UserModel() { }

        public UserModel(int type, string fullName, string email)
        {
            _type     = type;
            _fullName = fullName;
            _email    = email;
        }

        public UserModel(int type, string fullName, string email, string login, string password) : this(type, fullName, email)
        {
            _login    = login;
            _password = password;
        }

        #endregion

        #region Fields

        protected int    _type;
        protected string _fullName;
        protected string _email;
        protected string _login;
        protected string _password;

        #endregion

        #region Properties

        public string Email
        {
            get { return _email; }
            set
            { if (_email != value)
            {
                _email = value;
                OnPropertyChanged("Email");
            } }
        }

        public string Login
        {
            get { return _login; }
            set
            { if (_login != value)
            {
                _login = value;
                OnPropertyChanged("Num");
            } }
        }
        public string Password
        {
            get { return _password; }
            set
            { if (_password != value)
            {
                _password = value;
                OnPropertyChanged("Num");
            } }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            { if (_fullName != value)
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            } }
        }
        public int UType
        {
            get { return _type; }
            set
            { if (_type != value)
            {
                _type = value;
                OnPropertyChanged("UType");
            } }
        }

        #endregion

    }
}