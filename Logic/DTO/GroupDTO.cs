namespace Logic.DTO
{
    public class GroupDTO
    {
        public GroupDTO(long idGroup, string nameOfGroup)
        {
            Id          = idGroup;
            NameOfGroup = nameOfGroup;
        }
        public GroupDTO(Data.Maps.Group group)
        {
            Id          = group.ID_Group;
            NameOfGroup = group.NameOfGroup;
        }


        public long   Id          {get; set;}
        public string NameOfGroup {get; set;}
    }
}