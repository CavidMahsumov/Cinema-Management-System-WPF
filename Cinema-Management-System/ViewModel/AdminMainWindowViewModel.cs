using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Mail;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Cinema_Management_System.ViewModel
{
    public class AdminMainWindowViewModel:BaseViewModel
    {
        public RelayCommand AddButtonCommand { get; set; }
        public RelayCommand LogoutButtonCommand { get; set; }
        public RelayCommand SendMailButtonCommand { get; set; }
        public RelayCommand EditButtonCommand { get; set; }
        public RelayCommand RemoveButtonCommand { get; set; }
        public RelayCommand ViewFilmButtonCommand { get; set; }
        public RelayCommand UploadButtonCommand { get; set; }/// <summary>
        /// /
        /// </summary>
        /// <param name="adminMainWindow"></param>
        public AdminMainWindowViewModel(AdminMainWindow adminMainWindow)
        {
            RemoveButtonCommand = new RelayCommand((r) =>
            {
                RemoveWindow removeWindow = new RemoveWindow();
                removeWindow.ShowDialog();

            });
            
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
            UploadButtonCommand = new RelayCommand((e) =>
            {

                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                if (op.ShowDialog() == true)
                {
                    adminMainWindow.Profilepic.Source = new BitmapImage(new Uri(op.FileName));
                }

            });
            ViewFilmButtonCommand = new RelayCommand((w) =>
            {
                ViewFilmsWindow viewFilmsWindow = new ViewFilmsWindow();
                viewFilmsWindow.ShowDialog();

            });
        }
    }
}
