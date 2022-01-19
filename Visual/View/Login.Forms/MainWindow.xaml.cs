using Logic.DTO;
using System.Windows;
using System.Windows.Input;
using Logic.Processes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logic.Interfaces;
using System.Linq;

namespace Visual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserDTO                       _currentUser;
        readonly IUser                user = Logic.Configuration.IocKernel.Get<IUser>();
        ObservableCollection<UserDTO> _usersCollection;
        public MainWindow()
        {
            _usersCollection = user.GetListEntity();
            InitializeComponent();
        }

        // перемещение окна "за картинку"
        private void LogoContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length > 0)
            {
                RemovableText.Visibility = Visibility.Collapsed;
            }
            else
            {
                RemovableText.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //_currentUser = user.Authorization("papov", "papov");        // student        pppp@mail.ru
                //_currentUser = user.Authorization("admin", "admin");       //admin
                //_currentUser = user.Authorization("holo", "holo");         //methodist
                //_currentUser = user.Authorization("petrov", "petrov");        //teacher
                _currentUser = user.Authorization(TextBoxLogin.Text, passwordBox.Password);
            }
            catch
            {
                MessageBox.Show("Не верный логин или пароль!");
                return;
            }


            switch (_currentUser.Type)
            {
                case 1:
                    //AdminsWindows.AdminsStartWindow adW = new(_currentUser);
                    AdminsWindows.AdminsStartWindow adW = new();
                    Close();
                    adW.Show();
                    break;
                case 2:
                    View.Student.Forms.StudentsStartWindow stW = new View.Student.Forms.StudentsStartWindow(_currentUser);
                    //View.Student.Forms.StudentsStartWindow stW = new();
                    this.Close();
                    stW.Show();
                    break;
                //case 3:
                //    //View.Teacher.Form.MainTeacher teW = new View.Teacher.Form.MainTeacher(_currentUser);
                //    View.Teacher.Form.MainTeacher teW = new View.Teacher.Form.MainTeacher();
                //    this.Close();
                //    teW.Show();
                //    break;
                //case 4:
                //    View.Methodist.Forms.MethodistStartWindow weW = new View.Methodist.Forms.MethodistStartWindow();
                //    this.Close();
                //    weW.Show();
                //    break;
                default:
                    View.Teacher.Form.MainTeacher teacherOrMethW = new View.Teacher.Form.MainTeacher(_currentUser);
                    this.Close();
                    teacherOrMethW.Show();
                    break;
            }

            //AdminsWindows.AdminsStartWindow adW = new();
            //this.Close();
            //adW.Show();

            //View.Methodist.Forms.MethodistStartWindow mew = new();
            //mew.Show();
            //View.Methodist.Forms.QuizesWindow qw = new();
            //qw.Show();
            //View.Quiz.Form.QuizWindow qw = new(2);
            //qw.Show();
            //View.Quiz.Form.QuizCreationWindow qcw = new();
            //qcw.Show();
            //View.Student.Forms.StudentsStartWindow stW = new();
            //this.Close();
            //stW.Show();
        }
    }
}