using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Models;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Cinema_Management_System.ViewModel
{
   public class AdminViewWindowViewModel:BaseViewModel
    {
        public ObservableCollection<Film> Films { get; set; }
        public RelayCommand BackButtonClick { get; set; }
        public UserWindow userWindow { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        private Film film;

        public Film Film
        {
            get { return film; }
            set { film = value; OnPropertyChanged(); }
        }


        public AdminViewWindowViewModel(AdminViewFilmsWindow adminViewFilmsWindow)
        {
            Films = new ObservableCollection<Film>(FakeRepo.Films);
            BackButtonClick = new RelayCommand((back) =>
            {

                adminViewFilmsWindow.Close();

            });
            SelectedItemChangedCommand = new RelayCommand((c) =>
            {
                ClassHelper.Film.Time = new List<string>();
                SelectedFilmUserControl selected = new SelectedFilmUserControl();
                selected.FilmNameTextBlock.Text = ClassHelper.Film.Name;
                selected.DescriptiontextBlock.Text = ClassHelper.Film.Description;
                selected.selectImage.Source = new BitmapImage(new Uri(
                ClassHelper.Film.ImagePath, UriKind.RelativeOrAbsolute)); 
                ClassHelper.Film = Film;
                ClassHelper.viewfilm.mGrid.Children.Add(selected);


            });
        }
    }
}
