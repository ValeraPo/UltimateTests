using Logic.DTO;
using Logic.Interfaces;
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
using System.Windows.Shapes;

namespace Visual.View.Quiz.Form
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        QuizViewModel qvm;
        //ctor
        public QuizWindow(long QuizID)
        {
            InitializeComponent();
            qvm = new QuizViewModel((long)2);
            this.DataContext = qvm;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    ((QuizViewModel)DataContext).CurIndex++;
        //}
    }
}
