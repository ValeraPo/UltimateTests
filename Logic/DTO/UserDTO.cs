namespace Logic.DTO
{
    public class UserDTO
    {
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
        
        
        public long   Id       {get; set;}
        public int    Type     {get; set;}
        public string FullName {get; set;}
        public string Email    {get; set;}
        public string Group    {get; set;}
    }
}