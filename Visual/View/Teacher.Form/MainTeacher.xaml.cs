using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Visual.View.Quiz.Form;

namespace Visual.View.Teacher.Form
{
    /// <summary>
    /// Interaction logic for MainTeacher.xaml
    /// </summary>
    public partial class MainTeacher : Window
    {
        readonly ISetTag                         st  = Logic.Configuration.IocKernel.Get<ISetTag>();
        readonly IQuizze                         qui = Logic.Configuration.IocKernel.Get<IQuizze>();
        readonly IGroup                          gri = Logic.Configuration.IocKernel.Get<IGroup>();
        readonly ObservableCollection<SetTagDTO> _currentTagList;
        readonly ObservableCollection<SetTagDTO> _setTags;
        readonly ObservableCollection<QuizzeDTO> _quizzes;
        ObservableCollection<GroupDTO>           _groupsTeachers;

        readonly ObservableCollection<GroupTreeViewModel> _users;

        readonly ObservableCollection<AttemptDTO> _attemptDTO;
        readonly IUser                            user = Logic.Configuration.IocKernel.Get<IUser>();

        readonly UserDTO _currentUser;
        public MainTeacher(UserDTO currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            if (_currentUser.Type == 4)
            {

                #region Methodist

                appButt.Visibility = Visibility.Collapsed;
                addButt.Visibility = Visibility.Visible;
                delButt.Visibility = Visibility.Visible;

                _quizzes = qui.GetListEntity();
                _setTags = st.GetListEntity();

                QuizeListBox.ItemsSource    = _quizzes;
                tagsComboBox.ItemsSource    = _setTags;
                _currentTagList             = new ObservableCollection<SetTagDTO>();
                CurrentTagsList.ItemsSource = _currentTagList;

                _users = new ObservableCollection<GroupTreeViewModel>();
                foreach (var el in gri.GetListEntity())
                {
                    _users.Add(new GroupTreeViewModel(el));
                }
                treeView1.ItemsSource = _users;

                _attemptDTO                = Logic.Configuration.IocKernel.Get<IAttempt>().GetListEntity();
                QuizesListView.ItemsSource = _attemptDTO;

                #endregion

            }
            else
            {

                #region Teacher

                appButt.Visibility = Visibility.Visible;

                _quizzes = qui.GetListEntity();
                _setTags = st.GetListEntity();

                QuizeListBox.ItemsSource    = _quizzes;
                tagsComboBox.ItemsSource    = _setTags;
                _currentTagList             = new ObservableCollection<SetTagDTO>();
                CurrentTagsList.ItemsSource = _currentTagList;

                _groupsTeachers = user.GetListGroupTeacher();
                _users          = new ObservableCollection<GroupTreeViewModel>();
                foreach (var el in user.GetListGroupTeacher())
                {
                    //if ()
                    _users.Add(new GroupTreeViewModel(el));
                }
                treeView1.ItemsSource = _users;

                _attemptDTO                = Logic.Configuration.IocKernel.Get<IAttempt>().GetListEntity();
                QuizesListView.ItemsSource = _attemptDTO;

                #endregion

            }
        }

        public void CurrentTagsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = (SetTagDTO)tagsComboBox.SelectedValue;
            _currentTagList.Remove(temp);
        }

        private void tagsComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var temp = (SetTagDTO)tagsComboBox.SelectedValue;

            if (!_currentTagList.Contains(temp))
            {
                _currentTagList.Add(temp);
            }
        }

        private void startButt_Click(object sender, RoutedEventArgs e)
        {
            if (((QuizzeDTO)QuizeListBox.SelectedItem) == null)
                return;
            QuizWindow qw = new(this, ((QuizzeDTO)QuizeListBox.SelectedItem).Id, true);
            qw.Show();
            Hide();
        }

        private void appButt_Click(object sender, RoutedEventArgs e) //назначить
        {
            QuizCreationForm qcf = new QuizCreationForm(_currentUser, ((QuizzeDTO)QuizeListBox.SelectedItem));
        }

        private void delButt_Click(object sender, RoutedEventArgs e)
        {
            if (((QuizzeDTO)QuizeListBox.SelectedItem) == null)
                return;
            qui.RemoveQuizze(((QuizzeDTO)QuizeListBox.SelectedItem));
        }

        private void infoButt_Click(object sender, RoutedEventArgs e)
        {
            if (((QuizzeDTO)QuizeListBox.SelectedItem) == null)
                return;
            QuizCreationForm qcf = new(_currentUser, ((QuizzeDTO)QuizeListBox.SelectedItem));
        }
    }
}