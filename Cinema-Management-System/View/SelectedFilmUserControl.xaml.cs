using Cinema_Management_System.Extentesion;
using Cinema_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cinema_Management_System.View
{
    /// <summary>
    /// Interaction logic for SelectedFilmUserControl.xaml
    /// </summary>
    public partial class SelectedFilmUserControl : UserControl
    {
        public SelectedFilmUserControl()
        {
            InitializeComponent();
            ClassHelper.selectedUserControl = this;
            DataContext = new SelectedFilmUserControlViewModel();
        }
    }
}
