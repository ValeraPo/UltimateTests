using System.Collections.ObjectModel;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IUser
    {
        public UserDTO GetEntity(long id);
        public ObservableCollection<UserDTO> GetListEntity();
    }
}