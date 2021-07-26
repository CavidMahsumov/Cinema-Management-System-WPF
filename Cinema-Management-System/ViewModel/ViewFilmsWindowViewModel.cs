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
    public class ViewFilmsWindowViewModel:BaseViewModel
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


        public ViewFilmsWindowViewModel()
        {
            
            ClassHelper.UserWindow.Close();

            Films = new ObservableCollection<Film>(FakeRepo.getAll());
            BackButtonClick = new RelayCommand((s) =>
            {
                ClassHelper.viewfilm.Close();
                userWindow = new UserWindow();
                userWindow.ShowDialog();

            });

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) =>
            {
                SelectedFilmUserControl selected = new SelectedFilmUserControl();
                var item = SelectedItem as Film;
                Film = item;
                selected.FilmNameTextBlock.Text = Film.Name;
                selected.DescriptiontextBlock.Text = Film.Description;
                selected.selectImage.Source = new BitmapImage(new Uri(
                 Film.ImagePath, UriKind.RelativeOrAbsolute));
                ClassHelper.viewfilm.mGrid.Children.Add(selected);



            });
        }
    }
}
