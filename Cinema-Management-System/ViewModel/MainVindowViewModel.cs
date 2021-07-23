using Cinema_Management_System.Command;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_Management_System.ViewModel
{
   public class MainVindowViewModel:BaseViewModel
    {
        public RegisterControlViewModel RegisterControlViewModel { get; set; }
        public RelayCommand ClickCommand { get; set; }
        public Grid MainGrid { get; set; }

        public MainVindowViewModel(Grid mainGrid)
        {
            MainGrid = mainGrid;


            ClickCommand = new RelayCommand((s) =>
              {
                  RegisterControlViewModel = new RegisterControlViewModel();

                  MainGrid.Children.Add(new RegisterControl(RegisterControlViewModel));
              });
        }
    }
}
