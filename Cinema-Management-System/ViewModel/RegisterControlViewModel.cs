using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Models;
using Cinema_Management_System.Repository;
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
        RegisterControl RegisterControl { get; set; }
       public  MainWindow mainWindow { get; set; }
       public  UserWindow UserWindow { get; set; }
       public  RelayCommand submitButtonCommand { get; set; }

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }
        public RegisterControlViewModel(RegisterControl registerControl)
        {
            UserWindow = new UserWindow();
            RegisterControl = registerControl;
            //registerControl = new RegisterControl();
            submitButtonCommand = new RelayCommand((s) =>
              {
                  FakeRepo.User = new User();
                  FakeRepo.User.ID = 1;
                  FakeRepo.User.Name = registerControl.NameTxtBox.Text;
                  FakeRepo.User.Surname = registerControl.SurnameTxtBox.Text;
                  FakeRepo.User.Email = RegisterControl.EmailTxtBox.Text;
                  FakeRepo.User.Password = RegisterControl.PasswordTxtBox.Text;
                  UserWindow.namesurnameblock.Text = $"{FakeRepo.User.Name} {FakeRepo.User.Surname}";
                  FakeRepo.Users.Add(FakeRepo.User);
                  MainVindowViewModel.DataBase.Users.Add(FakeRepo.User);
                  JsonFileHelper.JSONSerialization(MainVindowViewModel.DataBase);
                  ClassHelper.MainWindow.Close();
                  UserWindow.ShowDialog();
                  
                  
              }
            );
        }
    }
}
