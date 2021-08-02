using Cinema_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Repository
{
  public  static  class FakeRepo
    {
        static public List<User> Users { get; set; } = new List<User>();

        static public User User { get; set; }
        static public User OldUser { get; set; }
        static public ObservableCollection<Film> Films = new ObservableCollection<Film>();

        public static ObservableCollection<Film> getAll()
        {
            return Films;
       
        }
        public static ObservableCollection<Admin> GetAdmins()
        {
            return new ObservableCollection<Admin>
            {
                new Admin
                {
                     Name="Cavid",
                      Email="mehsumovcavid@gmail.com",
                       Surname="Mahsumov",
                        Password="Cavid123"
                },
                new Admin
                {
                     Name="Tural",
                      Email="turaltahirli@gmail.com",
                       Surname="Tahirli",
                        Password="Tural123"
                }
            };
        }
    }
}
