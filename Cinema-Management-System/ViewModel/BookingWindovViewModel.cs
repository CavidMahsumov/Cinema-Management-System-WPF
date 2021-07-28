using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Models;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModel
{
   public  class BookingWindovViewModel:BaseViewModel
    {
        public RelayCommand BackBtnCommand { get; set; }
        public RelayCommand ButtonClick { get; set; }
        public RelayCommand SelectedTimeChangedCommand { get; set; }
        private Film film;

        public Film Film
        {
            get { return film; }
            set { film = value; OnPropertyChanged(); }
        }

        public BookingWindovViewModel( BookingWindow bookingWindow)
        {
            Film = ClassHelper.Film;
            BackBtnCommand = new RelayCommand((b) =>
            {
                ClassHelper.BookingVindow.Close();
                UserWindow userWindow = new UserWindow();
                userWindow.ShowDialog();

            });
            SelectedTimeChangedCommand = new RelayCommand((s) =>
            {
                bookingWindow.FilmComboBox1.ItemsSource = ClassHelper.Film.Time;

            });
        }
           
    }
}
