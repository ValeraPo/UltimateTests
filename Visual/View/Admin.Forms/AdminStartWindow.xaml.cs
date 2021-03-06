using Logic.DTO;
using System;
using System.Windows;
using Visual.View.Admin.Forms;

namespace Visual.AdminsWindows
{
    /// <summary>
    /// Interaction logic for AdminsStartWindow.xaml
    /// </summary>
    public partial class AdminsStartWindow : Window
    {
        readonly AdminViewModel av;
        public AdminsStartWindow(UserDTO currentAdmin)
        {
            InitializeComponent();
            av                         = new();
            groupListBox.ItemsSource   = av.GroupsList;
            groupListBox.SelectedItem  = av.GroupsList[0];
            ComboBoxLists.SelectedItem = ComboBoxLists.Items[0];
            //GroupListView.ItemsSource = av.CurrentUsersList;
            UsersListView.ItemsSource = av.StudentsList;
        }
        public AdminsStartWindow()
        {
            InitializeComponent();
            av                         = new();
            groupListBox.ItemsSource   = av.GroupsList;
            groupListBox.SelectedItem  = av.GroupsList[0];
            ComboBoxLists.SelectedItem = ComboBoxLists.Items[0];
            //GroupListView.ItemsSource = av.CurrentUsersList;
            UsersListView.ItemsSource = av.StudentsList;
        }

        private void groupListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (ComboBoxLists.Text == "Список студентов")
            {
                av.SelectStudents((GroupDTO)groupListBox.SelectedValue);
            }
            else //if (ComboBoxLists.Text == "Список преподавателей")
            {
                av.SelectTeachers((GroupDTO)(groupListBox.SelectedValue)); //нужен запрос из студентов по группе
            }
        }

        //private void TypeEmployerComboBox_DropDownClosed(object sender, EventArgs e)
        //{
        //    int curIndex = AdminView.GetIndexOfUserTypeByText(TypeEmployerComboBox.Text);
        //    av.CurrentEmployersList = av.GetCurrentEmployers(curIndex);
        //    EmployersListView.ItemsSource = av.CurrentEmployersList;
        //}

        private void ComboBoxLists_DropDownClosed(object sender, EventArgs e)
        {

            groupListBox_SelectionChanged(null, null);
        }
    }
}