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

namespace Visual.AdminsWindows
{
    /// <summary>
    /// Interaction logic for AdminsStartWindow.xaml
    /// </summary>
    public partial class AdminsStartWindow : Window
    {
        IGroup group = Logic.Configuration.IocKernel.Get<IGroup>();
        IUser user = Logic.Configuration.IocKernel.Get<IUser>();
        public AdminsStartWindow()
        {
            InitializeComponent();
            try
            {
                ObservableCollection<GroupDTO> groupsList = group.GetListEntity();
                ObservableCollection<UserDTO> studentsList = user.GetListStud();
                ObservableCollection<UserDTO> teachersList = user.GetListTeacher();
                TeachersList.ItemsSource = teachersList;
                StudentsList.ItemsSource = studentsList;
                GroupsList.ItemsSource = groupsList;
                GroupsList2.ItemsSource = groupsList;
            }
            catch (Exception)
            {
                MessageBox.Show("Something Wents wrong!");
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.Forms.AddOrChange aoc = new();
            aoc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //user.RemoveUser(user)

        }
    }
}
