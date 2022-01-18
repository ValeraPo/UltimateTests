using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual.ViewModel
{
    internal class AuthViewModel
    {
        UserDTO _currentUser;
        IUser user = Logic.Configuration.IocKernel.Get<IUser>();
        ObservableCollection<UserDTO> _usersCollection;

        AuthViewModel()
        {
            
           
        }
    }
}
