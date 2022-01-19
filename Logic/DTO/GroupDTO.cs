namespace Logic.DTO
{
    public class GroupDTO : AbstractOnPropertyChanged
    {
        private string _nameOfGroup;


        public GroupDTO(long idGroup, string nameOfGroup)
        {
            Id          = idGroup;
            NameOfGroup = nameOfGroup;
        }
        public GroupDTO(string nameOfGroup)
        {
            NameOfGroup = nameOfGroup;
        }
        public GroupDTO(Data.Maps.Group group)
        {
            Id          = group.ID_Group;
            NameOfGroup = group.NameOfGroup;
        }


        public long Id {get; set;}
        public string NameOfGroup
        {
            get => _nameOfGroup;
            set
            { if (_nameOfGroup == value)
                  return;
              _nameOfGroup = value;
              OnPropertyChanged(nameof(NameOfGroup)); }
        }
    }
}