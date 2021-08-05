using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Mail;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModel
{
    public class AdminMainWindowViewModel:BaseViewModel
    {
        public RelayCommand AddButtonCommand { get; set; }
        public RelayCommand LogoutButtonCommand { get; set; }
        public RelayCommand SendMailButtonCommand { get; set; }
        public RelayCommand EditButtonCommand { get; set; }
        public AdminMainWindowViewModel(AdminMainWindow adminMainWindow)
        {
            AddButtonCommand = new RelayCommand((s) =>
            {
                ClassHelper.adminWindow = adminMainWindow;
                adminMainWindow.Close();
                AddFilmWindow addFilmWindow = new AddFilmWindow();
                addFilmWindow.ShowDialog();
            });
            LogoutButtonCommand = new RelayCommand((l) =>
            {
                adminMainWindow.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();

            });
            SendMailButtonCommand = new RelayCommand((sm) =>
            {
                SendMail.SendMail1(FakeRepo.Admin.Email);

            });
            EditButtonCommand = new RelayCommand((e) =>
            {
                AdminEditWindow adminEditWindow = new AdminEditWindow();
                FakeRepo.OldAdmin = FakeRepo.Admin;

                adminEditWindow.ShowDialog();

            });
        }
    }
}
