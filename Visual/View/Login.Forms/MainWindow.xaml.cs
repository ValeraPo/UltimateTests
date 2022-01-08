using Logic.DTO;
using System.Windows;
using System.Windows.Input;
using Logic.Processes;
using System.Collections.Generic;

namespace Visual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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
            //TODO classes at Processes should be static!??????? !?
            //авторизация 
            //UserDTO currentUser;
            //try
            //{
            //    currentUser = User.Authorization(textBoxLogin.Text, passwordBox.Password); 
            //}
            //catch (KeyNotFoundException ex)
            //{
            //    MessageBox.Show("Неверный логин или пароль");
            //}

            //AdminsWindows.AdminsStartWindow asw = new();
            //asw.Show();

            View.Methodist.Forms.MethodistStartWindow mew = new();
            View.Methodist.Forms.QuizesWindow qw = new();
            mew.Show();
            qw.Show();
        }
    }
}