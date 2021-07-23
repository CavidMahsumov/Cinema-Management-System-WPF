using Cinema_Management_System.Command;
using Cinema_Management_System.View;
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

namespace Cinema_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RelayCommand ClickCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ClickCommand = new RelayCommand((s) =>
            {
               MessageBox.Show("Test");
                //RegisterControlViewModel = new RegisterControlViewModel();

                //MainGrid.Children.Add(new RegisterControl(RegisterControlViewModel));
            });
            DataContext = this;
            //MainVindowViewModel vm = new MainVindowViewModel(MainGrid);
            //DataContext = vm;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            //UserWindow userWindow = new UserWindow();
            //userWindow.ShowDialog();

        }
 
    }
}
