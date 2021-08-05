using Cinema_Management_System.Command;
using Cinema_Management_System.Models;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Admin> Admins { get; set; } = new ObservableCollection<Admin>();
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
     

        public MainVindowViewModel(Grid mainGrid,MainWindow mainWindow)
        {
            AdminMainWindow adminMainWindow = new AdminMainWindow();

            MainGrid = mainGrid;
            mainwindow = mainWindow;
            UserWindow = new UserWindow();
            Admins = FakeRepo.GetAdmins();
            Users = FakeRepo.Users;
            sumbitBtnClick = new RelayCommand((b) =>
            {
                if (FakeRepo.Users != null)
                {
                    foreach (var item in Users)
                    {
                        if (item.Email == mainwindow.emailtxtBox.Text && item.Password == mainwindow.passwordtxtpox.Text)
                        {
                            UserWindow.namesurnameblock.Text = $"{item.Name} {item.Surname}";


                            UserWindow.ShowDialog();
                            mainWindow.Close();
                        }

                    }
                }
                if (Admins != null)
                {
                    foreach (var item in Admins)
                    {
                        if (item.Email == mainwindow.emailtxtBox.Text && item.Password == mainwindow.passwordtxtpox.Text)
                        {
                            FakeRepo.Admin = item;
                            adminMainWindow.namesurnameblock.Text = $"{item.Name} {item.Surname}";
                            adminMainWindow.ShowDialog();
                            mainWindow.Close();
                        }
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

    public class ObsarvableCollection
    {
    }
}
