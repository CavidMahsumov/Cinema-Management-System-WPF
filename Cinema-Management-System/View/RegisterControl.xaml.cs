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
       MainWindow MainWindow { get; set; } 
        public RegisterControl(RegisterControlViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            //DataContext = new RegisterControlViewModel()
            //{
            //    //registerControl = this
            //};
            //MainWindow = new MainWindow();
            UserWindow UserWindow = new UserWindow();
            submitCommand = new RelayCommand((s) =>
            {
                User user = new User();
                user.ID = 1;
                user.Name = "Cavid";
                user.Surname = "Mahsumov";
                //user.Email = registerControl.EmailTxtBox.Text;
                //user.Password = registerControl.PasswordTxtBox.Text;
                //UserWindow.namesurnameblock.Text = $"{user.Name} {user.Surname}";

                UserWindow.ShowDialog();


            }
            );

        }
        public RelayCommand submitCommand { get; set; }
        //private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow.registerControl.Visibility = Visibility.Hidden;
        //}
    }
}

