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
        IGroup gr = Logic.Configuration.IocKernel.Get<IGroup>();
        //IGroup gr = new Logic.Processes.Group();
        public AdminsStartWindow()
        {
            InitializeComponent();
            try
            {
                ObservableCollection<GroupDTO> groupsList = gr.GetListEntity();
                GroupsList.ItemsSource = groupsList;
                GroupsList2.ItemsSource = groupsList;
            }
            catch (Exception)
            {
                MessageBox.Show("Something Wents wrong!");
                this.Close();
            }
        }

    }
}
