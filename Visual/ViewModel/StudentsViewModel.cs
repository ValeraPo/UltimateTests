using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Visual.Model;

namespace Visual.ViewModel
{
    internal class StudentsViewModel
    {
        readonly IUser              userI = Logic.Configuration.IocKernel.Get<IUser>();
        readonly IAppointmentQuizze apqI  = Logic.Configuration.IocKernel.Get<IAppointmentQuizze>();
        readonly IQuizze            quiI  = Logic.Configuration.IocKernel.Get<IQuizze>();
        IAttempt                    attI  = Logic.Configuration.IocKernel.Get<IAttempt>();

        public UserDTO _userDTO;
        ObservableCollection<AppointmentQuizzeDTO> _apDTO;
        ObservableCollection<QuizzeDTO> _quiDTO;
        ObservableCollection<AttemptDTO> _attDTO;

        UserModel studentM;
        ObservableCollection<AppointmentModel> _usersAttempts;
        public StudentsViewModel(long id)
        {
            //load from DB
            _userDTO = userI.GetEntity(id);
            _apDTO = apqI.GetListEntity();
            _quiDTO = quiI.GetListEntity();
            _attDTO = userI.GetListUserAttempt(_userDTO);// попытки по пользователю

            //init ViewModels
            studentM = new StudentModel             //Current Student
            {
                Group = _userDTO.Group,
                UType = _userDTO.Type,
                FullName = _userDTO.FullName,
                Email = _userDTO.Email
            };
            




            //init Commands
            //ClickCommand = new Command(arg => ClickMethod());

            //People = new PeopleModel
            //{
            //    FirstName = "First name",
            //    LastName = "Last name"
            //};
            //http://svyatoslavpankratov.blogspot.com/2011/11/mvvm-pattern-1.html
        }



        #region Commands

        /// <summary>
        /// Get or set ClickCommand.
        /// </summary>
        public ICommand ClickCommand { get; set; }

        #endregion


        #region Methods

        /// <summary>
        /// Click method.
        /// </summary>
        private void ClickMethod()
        {
            MessageBox.Show("This is click command.");
        }

        #endregion
    }
}
