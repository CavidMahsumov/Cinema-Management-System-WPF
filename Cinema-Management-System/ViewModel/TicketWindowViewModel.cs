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
    public class TicketWindowViewModel:BaseViewModel
    {
        public RelayCommand LogoutBtnCLick { get; set; }
        public RelayCommand BackButtonClick { get; set; }
        public TicketWindowViewModel(TicketWindow ticketWindow)
        {
            LogoutBtnCLick = new RelayCommand((l) =>
            {
                ticketWindow.Close();
            });
            BackButtonClick = new RelayCommand((b) =>
            {
                ticketWindow.Close();
                BookingWindow bookingWindow = new BookingWindow();
                bookingWindow.ShowDialog();
            });
        }
    }
}
