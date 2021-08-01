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

        public static ObservableCollection<Film> getAll()
        {
            return new ObservableCollection<Film> {
            new Film
            {
                ID = 1,
                 Name="Teen Wolf",
                  Type="Fantastic",
                   Description="Fantasitic",
                    ImDb=9.1,
                     ImagePath="../Images/teenwolf.jpg",
                      Time=new List<string>
                      {
                          "17:00","13:00"
                      }

            },
            new Film
            {
                ID = 2,
                Name = "Lucifer",
                Type = "Fantastic",
                Description = "Fantasitic",
                ImDb = 8.7,
                ImagePath="../Images/lucifer.jpg",
                Time=new List<string>{
                    "14:00","19:00"
                }

                

            },
            new Film
            {
                ID = 3,
                Name = "RiverDale",
                Type = "Teenager",
                Description = "Teenahger",
                ImDb = 8.1,
                ImagePath="../Images/riverdale.jpg"
                ,Time=new List<string>{
                    "19:00","22:00"
                }


            },
            new Film
            {
                ID = 4,
                Name = "The Vampire Diares",
                Type = "Fantastic",
                Description = "Fantasitic",
                ImDb = 8.9,
                ImagePath="../Images/vapire.jpg",
                Time=new List<string>
                {
                    "20:00","14:00"
                }

            },
             new Film
            {
                ID = 5,
                Name = "The Orginals",
                Type = "Vampires",
                Description = "Fantasic",
                ImDb = 8.1,
                ImagePath="../Images/orginals.jpg",
                Time=new List<string>{
                    "21:00","16:00"
                
                }

                

            }
        };
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
