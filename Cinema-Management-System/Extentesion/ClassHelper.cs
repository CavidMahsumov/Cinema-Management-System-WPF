using Cinema_Management_System.Models;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Extentesion
{
    public static class ClassHelper
    {
        public static MainWindow MainWindow { get; set; }
        public static  UserWindow UserWindow { get; set; }
        public static ViewFilmsWindow viewfilm { get; set; }
        public static AdminViewFilmsWindow adminView { get; set; }
        public static BookingWindow BookingVindow { get; set; }
        public static SelectedFilmUserControl selectedUserControl { get; set; }
        public static AdminMainWindow  adminWindow { get; set; }

        public static  TicketWindow TicketWindow { get; set; }
        public static AddFilmWindow AddFilmWindow { get; set; } = new AddFilmWindow();
        public static Film Film { get; set; } = new Film();
    }
}
