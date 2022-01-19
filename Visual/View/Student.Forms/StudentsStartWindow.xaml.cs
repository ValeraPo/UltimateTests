using Logic.DTO;
using System.Windows;
using Visual.View.Quiz.Form;

namespace Visual.View.Student.Forms
{
    /// <summary>
    /// Interaction logic for StudentsStartWindow.xaml
    /// </summary>
    public partial class StudentsStartWindow : Window
    {
        readonly StudentUserView suv;
        public StudentsStartWindow(UserDTO currentUser)
        {
            InitializeComponent();
            suv                             = new(currentUser);
            appointmentsListBox.ItemsSource = suv.appQuizzes;
            DataContext                     = suv;
            resultssListView.ItemsSource    = suv.attempts;
        }

        private void startButt_Click(object sender, RoutedEventArgs e)
        {
            if (((AppointmentQuizzeDTO)appointmentsListBox.SelectedItem) == null)
                return;
            QuizWindow qw = new(this, suv.appQ.GetQuiz((AppointmentQuizzeDTO)appointmentsListBox.SelectedItem).Id);
            qw.Show();
            Hide();
        }
    }
}