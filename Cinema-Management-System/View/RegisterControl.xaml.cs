using Cinema_Management_System.Command;
using Cinema_Management_System.Models;
using Cinema_Management_System.ViewModel;
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

namespace Cinema_Management_System.View
{
    /// <summary>
    /// Interaction logic for RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl
    {
       
        public RegisterControl()
        {
            InitializeComponent();
            DataContext = new RegisterControlViewModel();
            //MainWindow = new MainWindow();
        }

        //private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow.registerControl.Visibility = Visibility.Hidden;
        //}
    }
}
