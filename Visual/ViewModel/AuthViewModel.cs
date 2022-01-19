using Logic.DTO;
using Logic.Interfaces;
using System.Collections.ObjectModel;

namespace Visual.ViewModel
{
    internal class AuthViewModel
    {
        UserDTO                       _currentUser;
        IUser                         user = Logic.Configuration.IocKernel.Get<IUser>();
        ObservableCollection<UserDTO> _usersCollection;

        AuthViewModel() { }
    }
}