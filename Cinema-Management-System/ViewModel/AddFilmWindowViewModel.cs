using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Models;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            SearchButtonClickCommand = new RelayCommand(async (sb) =>
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
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyB2hJQYD-AuCQXJoHBt7XCUFz_mYCC12nU",
                    ApplicationName = this.GetType().ToString()
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = $"{ClassHelper.Film.Name}  Official Trailer"; // Replace with your search term.
                searchListRequest.MaxResults = 1;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = await searchListRequest.ExecuteAsync();

                List<string> videos = new List<string>();
                List<string> channels = new List<string>();
                List<string> playlists = new List<string>();

                string v = "";

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items)
                {
                    switch (searchResult.Id.Kind)
                    {
                        case "youtube#video":
                            //   videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                            videos.Add(searchResult.Id.VideoId);
                            break;

                        case "youtube#channel":
                            channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                            break;

                        case "youtube#playlist":
                            playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                            break;
                    }
                }

                v = videos[0];


                // MessageBox.Show($" \n www./youtu.be/{v}");



                if (ClassHelper.AddFilmWindow.ChromiumBrowser.Address == null)
                {

                    //ClassHelper.AddFilmWindow.Stackyoutubewb.Visibility = Visibility.Visible;
                    ClassHelper.AddFilmWindow.ChromiumBrowser.Address = $@"https://www.youtube.com/embed/{v}";
                }


                if (ClassHelper.AddFilmWindow.ChromiumBrowser.Address != null)
                {

                    ClassHelper.AddFilmWindow.ChromiumBrowser.Address = string.Empty;
                    //ClassHelper.AddFilmWindow.ChromiumBrowser.Reload();
                    ClassHelper.AddFilmWindow.ChromiumBrowser.Address = $@"https://www.youtube.com/embed/{v}";






                }


            });
            AddButtonClickCommand = new RelayCommand(async (s) =>
            {
                try
                {
                    MainVindowViewModel.DataBase.Admins = FakeRepo.GetAdmins();
                    MainVindowViewModel.DataBase.Films.Add(ClassHelper.Film);

                    JsonFileHelper.JSONSerialization(MainVindowViewModel.DataBase);
                    FakeRepo.Films.Add(ClassHelper.Film);
                    MessageBox.Show("Film is Added") ;
                }
                catch (Exception ex)
                {

                }
               


            });
            BackButtonCommand = new RelayCommand((b) =>
            {
                addFilmWindow.Close();

                AdminMainWindow adminMainWindow = new AdminMainWindow();

                adminMainWindow.namesurnameblock.Text = $"{FakeRepo.Admin.Name} {FakeRepo.Admin.Surname} ";
                adminMainWindow.ShowDialog();

                
            });


        }
    }
}
