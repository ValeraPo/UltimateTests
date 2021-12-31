using System;
using System.Collections.Generic;
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

namespace WpfAppTrying
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
        
        View.Student.TaskPage taskPage;
        View.Student.StatPage statPage;
        

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            taskPage = new View.Student.TaskPage();
            Student.Content = taskPage;
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            statPage = new View.Student.StatPage();
            Student.Content = statPage;
        }
    }
}
