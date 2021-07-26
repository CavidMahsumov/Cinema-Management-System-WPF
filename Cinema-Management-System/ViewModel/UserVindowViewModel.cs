using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
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
    public class UserVindowViewModel : BaseViewModel
    {
        public RelayCommand LogoutBtn { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand UploadPhotoBtnCommand { get; set; }
        public RelayCommand ViewFilms { get; set; }
        public UserWindow UserWindow { get; set; }
        public EditWindowUser editWindow { get; set; }
        public MainWindow MainWindow { get; set; }
        public ViewFilmsWindow FilmVindows { get; set; }
        public RelayCommand ViewBookings { get; set; }

        public UserVindowViewModel(UserWindow userWindow)
        {
            ClassHelper.UserWindow = userWindow;

            LogoutBtn = new RelayCommand((l) =>
            {
                userWindow.Close();
                MainWindow = new MainWindow();
                MainWindow.ShowDialog();
            });
            EditCommand = new RelayCommand((e) =>
              {
                  editWindow = new EditWindowUser();
                  FakeRepo.OldUser = FakeRepo.User;

                  editWindow.ShowDialog();
              }

            );
            //DRAGDROB
            UploadPhotoBtnCommand = new RelayCommand((upl) =>
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                if (op.ShowDialog() == true)
                {
                    userWindow.Profilepic.Source = new BitmapImage(new Uri(op.FileName));
                }


            });
            ViewFilms = new RelayCommand((vf) =>
            {
                FilmVindows = new ViewFilmsWindow();
                FilmVindows.ShowDialog();

            });
            ViewBookings = new RelayCommand((vb) =>
            {
                ClassHelper.UserWindow.Close();
                BookingWindow bookingWindow = new BookingWindow();
                bookingWindow.ShowDialog();

            });
        }
    }
}
