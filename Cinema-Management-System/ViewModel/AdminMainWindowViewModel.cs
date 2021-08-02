using Cinema_Management_System.Command;
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
        public AdminMainWindowViewModel(AdminMainWindow adminMainWindow)
        {
            AddButtonCommand = new RelayCommand((s) =>
            {
                adminMainWindow.Close();
                AddFilmWindow addFilmWindow = new AddFilmWindow();
                addFilmWindow.ShowDialog();
            });
        }
    }
}
