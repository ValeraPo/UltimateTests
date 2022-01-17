namespace Logic.DTO
{
    public class UserDTO : AbstractOnPropertyChanged
    {
        private int    _type;
        private string _fullName;
        private string _email;
        private string _group;
        
        
        public UserDTO(long id, int type, string fullName, string email, string group)
        {
            Id       = id;
            Type     = type;
            FullName = fullName;
            Email    = email;
            Group    = group;
        }
        public UserDTO(int type, string fullName, string email, string group)
        {
            Type     = type;
            FullName = fullName;
            Email    = email;
            Group    = group;
        }
        public UserDTO(Data.Maps.User user)
        {
            Id       = user.ID_User;
            Type     = user.ID_Role;
            FullName = user.FullName;
            Email    = user.Email;
            Group    = user.Group?.NameOfGroup;
        }


        public long Id {get; set;}
        public int Type
        {
            get => _type;
            set
            { if (_type == value)
                  return;
              _type = value;
              OnPropertyChanged(nameof(Type)); }
        }
        public string FullName
        {
            get => _fullName;
            set
            { if (_fullName == value)
                  return;
              _fullName = value;
              OnPropertyChanged(nameof(FullName)); }
        }
        public string Email
        {
            get => _email;
            set
            { if (_email == value)
                  return;
              _email = value;
              OnPropertyChanged(nameof(Email)); }
        }
        public string Group
        {
            get => _group;
            set
            { if (_group == value)
                  return;
              _group = value;
              OnPropertyChanged(nameof(Group)); }
        }
    }
}