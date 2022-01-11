using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Visual.View.Admin.Forms
{
    /// <summary>
    /// Interaction logic for AddOrChange.xaml
    /// </summary>
    public partial class AddOrChange : Window
    {
        IGroup group = Logic.Configuration.IocKernel.Get<IGroup>();
        IUser user = Logic.Configuration.IocKernel.Get<IUser>();
        int _typeOfUser;
        ObservableCollection<GroupDTO> _groupsList;
        ObservableCollection<UserDTO> usersList;

        public AddOrChange()
        {
            InitializeComponent();

            usersList = user.GetListEntity();

            _groupsList = group.GetListEntity();
            GroupComboBox.ItemsSource = _groupsList;
            GroupComboBox.Visibility = Visibility.Visible;
        }

        public AddOrChange(UserDTO changingUser)
        {
            InitializeComponent();

            usersList = user.GetListEntity();
            _groupsList = group.GetListEntity();

            GroupComboBox.ItemsSource = _groupsList;
            TextBoxFIO.Text = changingUser.FullName;
            TextBoxEmail.Text = changingUser.Email;
            //TextBoxLogin.Text = changingUser.Login;
            //TextBoxPass.Text = changingUser.Pass;
            TypeComboBox.Text = changingUser.Type.ToString(); // заменить на соответсвующий текст
            GroupComboBox.Text = changingUser.Group;

            
        }


        private void TypeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (TypeComboBox.Text == "Студент")
            {
                GroupComboBox.Visibility = Visibility.Visible;
                _typeOfUser = 2; 
            }
            else if (TypeComboBox.Text == "Преподаватель")
            {
                GroupComboBox.Visibility = Visibility.Collapsed;
                _typeOfUser = 3; 
            }
            else if (TypeComboBox.Text == "Методист")
            {
                GroupComboBox.Visibility = Visibility.Collapsed;
                _typeOfUser = 4; 
            }
            else
            {
                GroupComboBox.Visibility = Visibility.Collapsed;
                _typeOfUser = 1; 
            }
        }
        //create user
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //groupsList.Single(t => t.NameOfGroup == GroupComboBox.Text);
            if (_typeOfUser == 2)
            {
                user.AddNewUser(TextBoxFIO.Text, TextBoxEmail.Text, TextBoxLogin.Text, TextBoxPass.Text, _typeOfUser, _groupsList.Single(t => t.NameOfGroup == GroupComboBox.Text).Id);
            }
            else
                user.AddNewUser(TextBoxFIO.Text, TextBoxEmail.Text, TextBoxLogin.Text, TextBoxPass.Text, _typeOfUser, null);
            usersList = user.GetListEntity();
        }
        //add group
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewGroup.Text != "")
                group.AddGroup(TextBoxNewGroup.Text);
            else
                MessageBox.Show("Поле группы не заполнено!");
            _groupsList = group.GetListEntity();
        }
        //change
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
