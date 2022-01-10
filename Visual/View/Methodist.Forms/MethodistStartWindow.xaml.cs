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
        ISetTag st = Logic.Configuration.IocKernel.Get<ISetTag>();
        IQuizze qui = Logic.Configuration.IocKernel.Get<IQuizze>();
        ObservableCollection<string> _currentTagList;
        
        public MethodistStartWindow()
        {
            InitializeComponent();
            ObservableCollection<SetTagDTO> setTags = st.GetListEntity();
            TagsComboBox.ItemsSource = setTags;
            ObservableCollection<QuizzeDTO> quizzes = qui.GetListEntity();
            QuizeList.ItemsSource = quizzes;
            _currentTagList = new ObservableCollection<string>();
            CurrentTagsListBox.ItemsSource = _currentTagList;

        }
        public void CurrentTagsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListBox lBox = (ListBox)sender;
            //ListBoxItem selectedItem = (ListBoxItem)lBox.SelectedItem;
            //MessageBox.Show(selectedItem.Content.ToString());
            //_currentTagList.Remove(selectedItem.Content.ToString());

        }

        private void TagsComboBox_DropDownClosed(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (var el in _currentTagList)
            {
                if (el == TagsComboBox.Text)
                    flag = true;
            }
            if (!flag)
                _currentTagList.Add(TagsComboBox.Text);
        }
    }
}
