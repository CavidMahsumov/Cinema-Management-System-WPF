using Cinema_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Extentesion
{
    public class DataBase
    {
          public  ObservableCollection<Admin> Admins { get; set; } = new ObservableCollection<Admin>();
         public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
         public ObservableCollection<Film> Films { get; set; } = new ObservableCollection<Film>();

    }
}
