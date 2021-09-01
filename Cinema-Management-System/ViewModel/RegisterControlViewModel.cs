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
        public RelayCommand NameCLick { get; set; }
        public RelayCommand SurnameClick { get; set; }
        public RelayCommand EmailCLick { get; set; }
        public RelayCommand PasswordClick { get; set; }

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


            });
            NameCLick = new RelayCommand((n) =>
            {

                registerControl.NameTxtBox.Text = string.Empty;

            });
            SurnameClick = new RelayCommand((s) =>
            {

                registerControl.SurnameTxtBox.Text = string.Empty;

            });
            EmailCLick = new RelayCommand((e) =>
            {
                registerControl.EmailTxtBox.Text = string.Empty;

            });
            PasswordClick = new RelayCommand((p) =>
            {

                registerControl.PasswordTxtBox.Text = string.Empty;
            });

        }
    }
}
