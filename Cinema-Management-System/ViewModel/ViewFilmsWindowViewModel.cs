using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Models;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
        public string ImagePath { get; set; }
        public string Minute { get; set; }
        public string Description { get; set; }


        public RelayCommand searchButtonClick { get; set; }

        public dynamic Data { get; set; }
        public dynamic SingleData { get; set; }

        HttpClient http = new HttpClient();


        public ViewFilmsWindowViewModel( ViewFilmsWindow viewFilmsWindow)
        {
            
            ClassHelper.UserWindow.Close();

            Films = MainVindowViewModel.DataBase.Films;
            BackButtonClick = new RelayCommand((s) =>
            {
                ClassHelper.viewfilm.Close();
                userWindow = new UserWindow();
                userWindow.namesurnameblock.Text = $"{FakeRepo.User.Name} {FakeRepo.User.Surname}";
                userWindow.ShowDialog();

            });

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) =>
            {
                var fi = SelectedItem as Film;

               // ClassHelper.Film.Time = new List<string>();
                SelectedFilmUserControl selected = new SelectedFilmUserControl();
                selected.FilmNameTextBlock.Text =fi.Name;
                selected.DescriptiontextBlock.Text = fi.Description;
                selected.selectImage.Source = new BitmapImage(new Uri(
               fi.ImagePath, UriKind.RelativeOrAbsolute));
              ClassHelper.Film = fi;
                ClassHelper.viewfilm.mGrid.Children.Add(selected);



            });
            searchButtonClick = new RelayCommand((ss) =>
            {
                

            });
        }
    }
}
