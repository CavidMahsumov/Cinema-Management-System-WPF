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
   public  class BookingWindovViewModel:BaseViewModel
    {
        public RelayCommand BackBtnCommand { get; set; }
        public RelayCommand ButtonClick { get; set; }
        public BookingWindovViewModel() 
        {
            BackBtnCommand = new RelayCommand((b) =>
            {
                ClassHelper.BookingVindow.Close();  
                UserWindow userWindow = new UserWindow();
                userWindow.ShowDialog();
                
            });
            ButtonClick = new RelayCommand((n) =>
            {


            });
        }
    }
}
