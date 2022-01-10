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
        ObservableCollection<GroupDTO> groupsList;
        

        public AddOrChange()
        {
            InitializeComponent();
            
            ObservableCollection<UserDTO> usersList = user.GetListEntity();

            groupsList = group.GetListEntity();
            GroupComboBox.ItemsSource = groupsList;

        }

        public AddOrChange(UserDTO changingUser)
        {
            InitializeComponent();

            ObservableCollection<UserDTO> usersList = user.GetListEntity();

            ObservableCollection<GroupDTO> groupsList = group.GetListEntity();
            GroupComboBox.ItemsSource = groupsList;
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
                _typeOfUser = 1; //TODO поменять на нужное
            }
            else if (TypeComboBox.Text == "Преподаватель")
            {
                GroupComboBox.Visibility = Visibility.Collapsed;
                _typeOfUser = 2; //TODO поменять на нужное
            }
            else if (TypeComboBox.Text == "Методист")
            {
                GroupComboBox.Visibility = Visibility.Collapsed;
                _typeOfUser = 3; //TODO поменять на нужное
            }
            else
            {
                GroupComboBox.Visibility = Visibility.Collapsed;
                _typeOfUser = 4; //TODO поменять на нужное
            }
        }
        //create user
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //long newId;
            //foreach (var el in groupsList)
            //{
            //    if (GroupComboBox.Text == el.NameOfGroup)
            //        newId = el.Id
            //}
            //(GroupDTO)GroupComboBox.SelectedItem.Id
            user.AddNewUser(TextBoxFIO.Text, TextBoxEmail.Text, TextBoxLogin.Text, TextBoxPass.Text, _typeOfUser, long.Parse(GroupComboBox.Text)); //херня - переделать
        }
        //add group
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewGroup.Text != "")
                group.AddGroup(TextBoxNewGroup.Text);
            else
                MessageBox.Show("Поле группы не заполнено!");
        }
        //change
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
