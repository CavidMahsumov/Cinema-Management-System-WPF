using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Models;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Cinema_Management_System.ViewModel
{
    public class AddFilmWindowViewModel:BaseViewModel
    {
        public RelayCommand SearchButtonClickCommand { get; set; }
        public RelayCommand AddButtonClickCommand { get; set; }
        public RelayCommand BackButtonCommand { get; set; }
        private Film film;

        public Film Film
        {
            get { return film; }
            set { film = value; OnPropertyChanged(); }
        }
        public string ImagePath { get; set; }
        public string Minute { get; set; }
        public string Description { get; set; }
        public dynamic Data { get; set; }
        public dynamic SingleData { get; set; }

        HttpClient http = new HttpClient();
        public AddFilmWindowViewModel(AddFilmWindow addFilmWindow)
        {
            SearchButtonClickCommand = new RelayCommand((sb) =>
            {
                ClassHelper.Film = new Film();
                try
                {
                    Film = new Film();
                   
                    HttpResponseMessage response = new HttpResponseMessage();
                    response =
                                          http.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&s={addFilmWindow.SearchtxtBox.Text}&plot=full").Result;
                    var str = response.Content.ReadAsStringAsync().Result;
                    Data = JsonConvert.DeserializeObject(str);
                    response =
                                              http.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&t={Data.Search[0].Title}&plot=full").Result;
                    str = response.Content.ReadAsStringAsync().Result;
                    SingleData = JsonConvert.DeserializeObject(str);



                    ImagePath = SingleData.Poster;
                    Minute = SingleData.Runtime;
                    Description = SingleData.Genre;



                    addFilmWindow.FilmImage.Source = new BitmapImage(new Uri(
                    ImagePath, UriKind.RelativeOrAbsolute));
                    addFilmWindow.FilmNameTextBloxk.Text = SingleData.Title;
                    ClassHelper.Film.Name = SingleData.Title;
                    ClassHelper.Film.ImagePath = SingleData.Poster;
                    ClassHelper.Film.Description = SingleData.Genre;
                    ClassHelper.Film.Time = SingleData.RunTime;
                    
                   
                }
                catch (Exception ex)
                {



                }

            });
            AddButtonClickCommand = new RelayCommand((s) =>
            {
                FakeRepo.Films.Add(ClassHelper.Film);

            });
            BackButtonCommand = new RelayCommand((b) =>
            {
                addFilmWindow.Close();

                AdminMainWindow adminMainWindow = new AdminMainWindow();
                adminMainWindow = ClassHelper.adminWindow;
                adminMainWindow.ShowDialog();
            });


        }
    }
}
