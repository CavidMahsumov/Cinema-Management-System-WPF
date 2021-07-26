using Cinema_Management_System.Command;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_Management_System.ViewModel
{
   public  class MainVindowViewModel:BaseViewModel
    {
        public RegisterControlViewModel RegisterControlViewModel { get; set; }
        public MainWindow mainwindow { get; set; }
        public RelayCommand ClickCommand { get; set; }
        public Grid MainGrid { get; set; }
        public  RelayCommand sumbitBtnClick { get; set;}
        public UserWindow UserWindow { get; set; }

        public MainVindowViewModel(Grid mainGrid,MainWindow mainWindow)
        {
            MainGrid = mainGrid;
            mainwindow = mainWindow;
            UserWindow = new UserWindow();
            sumbitBtnClick = new RelayCommand((b) =>
            {
                foreach (var item in FakeRepo.Users)
                {
                    if (item.Email == mainwindow.emailtxtBox.Text && item.Password == mainwindow.passwordtxtpox.Text)
                    {
                        UserWindow.namesurnameblock.Text = $"{item.Name} {item.Surname}";


                        UserWindow.ShowDialog();
                    }
                }
            });
            ClickCommand = new RelayCommand((s) =>
            {
                RegisterControl registerControl = new RegisterControl();
                MainGrid.Children.Add(registerControl);
            });
        }
    }
}
