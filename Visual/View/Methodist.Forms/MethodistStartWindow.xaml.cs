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
        ObservableCollection<string> _currentTags;
        public MethodistStartWindow()
        {
            InitializeComponent();
            _currentTags = new ObservableCollection<string> { "1111", "2", "3", "432"};
            
            CurrentTagsList.ItemsSource = _currentTags;
            
        }
        public void CurrentTagsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_currentTags.RemoveAt((sender as ListBox).SelectedIndex);
            _currentTags.RemoveAt(CurrentTagsList.SelectedIndex); //
        }
    }
}
