using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModel
{
    public class SelectedFilmUserControlViewModel:BaseViewModel
    {
        public RelayCommand BookKnowButtonCommand { get; set; }

        public SelectedFilmUserControlViewModel()
        {
            BookKnowButtonCommand = new RelayCommand((b) =>
            {
                ClassHelper.viewfilm.Close();
                BookingWindow bookingWindov = new BookingWindow();
                bookingWindov.ShowDialog();
            });
        }
    }
}
