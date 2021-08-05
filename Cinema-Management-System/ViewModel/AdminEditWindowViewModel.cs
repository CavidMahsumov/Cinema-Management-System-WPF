using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModel
{
   public class AdminEditWindowViewModel:BaseViewModel
    {
        public RelayCommand LogoutButtonCommand { get; set; }
        public RelayCommand SaveButtonCommand { get; set; }
        public AdminEditWindowViewModel(AdminEditWindow adminEditWindow)
        {
            LogoutButtonCommand = new RelayCommand((l) =>
            {
                adminEditWindow.Close();

            });
            SaveButtonCommand = new RelayCommand((save) =>
            {

                FakeRepo.Admin.Name = adminEditWindow.FisrtNameTxtBox.Text;
                FakeRepo.Admin.Surname = adminEditWindow.LastNametxtBox.Text;
                FakeRepo.Admin.Email = adminEditWindow.EmailTxtBox.Text;
                FakeRepo.Admin.Password = adminEditWindow.PasswordTxtBox.Text;
                adminEditWindow.FirstName.Text = FakeRepo.Admin.Name;
                adminEditWindow.LastName.Text = FakeRepo.Admin.Surname;
                adminEditWindow.Mail.Text = FakeRepo.Admin.Email;
                adminEditWindow.oldLastname.Text = FakeRepo.OldAdmin.Surname;
                adminEditWindow.oldname.Text = FakeRepo.OldAdmin.Name;
                adminEditWindow.oldmail.Text = FakeRepo.OldAdmin.Email;
                ClassHelper.UserWindow.namesurnameblock.Text = $"{FakeRepo.Admin.Name} {FakeRepo.Admin.Surname}";
            });
        }
    }
}
