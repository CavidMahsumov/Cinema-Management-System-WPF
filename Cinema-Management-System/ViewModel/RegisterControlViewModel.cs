using Cinema_Management_System.Command;
using Cinema_Management_System.Models;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModel
{
    public class RegisterControlViewModel:BaseViewModel
    {
       public  MainWindow mainWindow { get; set; }
       public  UserWindow UserWindow { get; set; }
       public  RegisterControl registerControl { get; set; }
       public  RelayCommand submitButtonCommand { get; set; }

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }
        public RegisterControlViewModel()
        {
            UserWindow = new UserWindow();
            registerControl = new RegisterControl();
            submitButtonCommand = new RelayCommand((s) =>
              {
                  User user = new User();
                  user.ID = 1;
                  user.Name = "Cavid";
                  user.Surname = "Mahsumov";
                  user.Email = registerControl.EmailTxtBox.Text;
                  user.Password = registerControl.PasswordTxtBox.Text;
                  UserWindow.namesurnameblock.Text = $"{user.Name} {user.Surname}";



                  UserWindow.ShowDialog();
                  
                  
              }
            );
        }
    }
}
