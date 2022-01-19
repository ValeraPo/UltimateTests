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

namespace Visual.View.Methodist.Forms
{
    /// <summary>
    /// Interaction logic for MethodistStartWindow.xaml
    /// </summary>
    public partial class MethodistStartWindow : Window
    {
        readonly ISetTag                         st  = Logic.Configuration.IocKernel.Get<ISetTag>();
        readonly IQuizze                         qui = Logic.Configuration.IocKernel.Get<IQuizze>();
        readonly ObservableCollection<SetTagDTO> _currentTagList;
        readonly ObservableCollection<SetTagDTO> setTags;

        IUser user = Logic.Configuration.IocKernel.Get<IUser>();
        IGroup group = Logic.Configuration.IocKernel.Get<IGroup>();

        public MethodistStartWindow()
        {
            InitializeComponent();
            //TabItem Tests
            setTags = st.GetListEntity();
            TagsComboBox.ItemsSource = setTags;
            ObservableCollection<QuizzeDTO> quizzes = qui.GetListEntity();
            QuizeList.ItemsSource = quizzes;
            _currentTagList = new ObservableCollection<SetTagDTO>();
            CurrentTagsListBox.ItemsSource = _currentTagList;

            //TabItem Statistic
            //ObservableCollection<UserDTO> studentsList = user.GetListStud();
            //ObservableCollection<GroupDTO> groupsList = group.GetListEntity();
           
            //GroupsTreeView.ItemsSource = groupsList;
            ////Students tree                                                                         <-----------TODO GetListStudByGroup()
            //StudentsTreeView.ItemsSource = studentsList;
            

            //Quizes tree
           // TagsTreeView.ItemsSource = setTags;
            QuizesTreeView.ItemsSource = quizzes;
        }
        public void CurrentTagsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(CurrentTagsListBox.SelectedValue.ToString());
            var temp = (SetTagDTO)CurrentTagsListBox.SelectedValue;
            _currentTagList.Remove(temp);
        }

        private void TagsComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var temp = (SetTagDTO)TagsComboBox.SelectedValue;
            
            if (!_currentTagList.Contains(temp))
            {
                _currentTagList.Add(temp);
            }
        }
    }
}
