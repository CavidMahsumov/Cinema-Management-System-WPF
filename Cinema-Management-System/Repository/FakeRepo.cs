using Cinema_Management_System.Models;
using System;
using System.Collections.Generic;
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

        public static List<Film> getAll()
        {
            return new List<Film> {
            new Film
            {
                ID = 1,
                 Name="Teen Wolf",
                  Type="Fantastic",
                   Description="Fantasitic",
                    ImDb=9.1,
                     ImagePath="../Images/teenwolf.jpg"

            },
            new Film
            {
                ID = 2,
                Name = "Lucifer",
                Type = "Fantastic",
                Description = "Fantasitic",
                ImDb = 8.7,
                ImagePath="../Images/lucifer.jpg"

            },
            new Film
            {
                ID = 3,
                Name = "RiverDale",
                Type = "Teenager",
                Description = "Teenahger",
                ImDb = 8.1,
                ImagePath="../Images/riverdale.jpg"

            },
            new Film
            {
                ID = 4,
                Name = "The Vampire Diares",
                Type = "Fantastic",
                Description = "Fantasitic",
                ImDb = 8.9,
                ImagePath="../Images/vapire.jpg"

            },
             new Film
            {
                ID = 5,
                Name = "The Orginals",
                Type = "Vampires",
                Description = "Fantasic",
                ImDb = 8.1,
                ImagePath="../Images/orginals.jpg"

            }
        };
        }
    }
}
