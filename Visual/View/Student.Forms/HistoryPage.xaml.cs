using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppTrying.View.Student.Model;

namespace WpfAppTrying.View.Student
{
    /// <summary>
    /// Interaction logic for HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        //private BindingList<HistoryList> _historyData;
        private ObservableCollection<HistoryList> _historyData;
        public HistoryPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _historyData = new ObservableCollection<HistoryList>()
            {
                new HistoryList() { Quiz = "задача 1", Teacher = "Anton" },
                new HistoryList() { Quiz = "задача 2", Teacher = "Andrey" },
            };
            dgHistory.ItemsSource = _historyData;
        }
    }
}
