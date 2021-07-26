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
    public class EditWindowViewModel:BaseViewModel
    {
        public EditWindowUser EditWindowUser { get; set; }
        public RelayCommand SaveBtn { get; set; }

        public RelayCommand LogoutBtn { get; set; }
        public EditWindowViewModel(EditWindowUser editWindowUser)
        {
            SaveBtn = new RelayCommand((s) =>
              {
                  FakeRepo.User.Name = editWindowUser.FisrtNameTxtBox.Text;
                  FakeRepo.User.Surname = editWindowUser.LastNametxtBox.Text;
                  FakeRepo.User.Email = editWindowUser.EmailTxtBox.Text;
                  FakeRepo.User.Password = editWindowUser.PasswordTxtBox.Text;
                  editWindowUser.FirstName.Text = FakeRepo.User.Name;
                  editWindowUser.LastName.Text = FakeRepo.User.Surname;
                  editWindowUser.Mail.Text = FakeRepo.User.Email;
                  editWindowUser.oldLastname.Text = FakeRepo.OldUser.Surname;
                  editWindowUser.oldname.Text = FakeRepo.OldUser.Name;
                  editWindowUser.oldmail.Text = FakeRepo.OldUser.Email;
                  ClassHelper.UserWindow.namesurnameblock.Text = $"{FakeRepo.User.Name} {FakeRepo.User.Surname}";
                  //editWindowUser.Close();
              });
            LogoutBtn = new RelayCommand((l) =>
            {
                editWindowUser.Close();
            });
        }
    }
}
