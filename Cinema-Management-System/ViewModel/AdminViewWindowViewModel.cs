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
    public class AdminViewWindowViewModel : BaseViewModel
    {
        public ObservableCollection<Film> Films { get; set; }
        public RelayCommand BackButtonClick1 { get; set; }
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
            Films = MainVindowViewModel.DataBase.Films;
            BackButtonClick1 = new RelayCommand((back) =>
            {

                adminViewFilmsWindow.Close();

            });
            SelectedItemChangedCommand = new RelayCommand((c) =>
            {
                var fi = c as Film;

                ClassHelper.Film.Time = new List<string>();
                SelectedFilmUserControl selected = new SelectedFilmUserControl();
                selected.FilmNameTextBlock.Text = fi.Name;
                selected.DescriptiontextBlock.Text = fi.Description;
                selected.selectImage.Source = new BitmapImage(new Uri(
                fi.ImagePath, UriKind.RelativeOrAbsolute));
                Film = ClassHelper.Film;
                selected.BookNowButton.Visibility = System.Windows.Visibility.Hidden;
                ClassHelper.adminView.mGrid.Children.Add(selected);


            });
        }
    }
}
