using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.View;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModel
{
    public class SelectedFilmUserControlViewModel:BaseViewModel
    {
        public RelayCommand BookKnowButtonCommand { get; set; }
        public RelayCommand ShowTrailerCommand { get; set; }

        public SelectedFilmUserControlViewModel()
        {
            ShowTrailerCommand = new RelayCommand(async (sh) =>
            {
                ClassHelper.selectedUserControl.selectImage.Visibility = System.Windows.Visibility.Hidden;
                ClassHelper.selectedUserControl.ShowTrailer.Visibility = System.Windows.Visibility.Visible;
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



                if (ClassHelper.selectedUserControl.ChromiumBrowser.Address == null)
                {

                    //ClassHelper.AddFilmWindow.Stackyoutubewb.Visibility = Visibility.Visible;
                    ClassHelper.selectedUserControl.ChromiumBrowser.Address = $@"https://www.youtube.com/embed/{v}";
                    ClassHelper.selectedUserControl.ShowTrailer.Visibility = System.Windows.Visibility.Hidden;
                }


                if (ClassHelper.selectedUserControl.ChromiumBrowser.Address != null)
                {

                    ClassHelper.selectedUserControl.ChromiumBrowser.Address = string.Empty;
                    //ClassHelper.AddFilmWindow.ChromiumBrowser.Reload();
                    ClassHelper.selectedUserControl.ChromiumBrowser.Address = $@"https://www.youtube.com/embed/{v}";


                    ClassHelper.selectedUserControl.ShowTrailer.Visibility = System.Windows.Visibility.Hidden;




                }


            });
            BookKnowButtonCommand = new RelayCommand((b) =>
            {
                //ClassHelper.viewfilm.Close();
                BookingWindow bookingWindov = new BookingWindow();
                bookingWindov.ShowDialog();
            });
        }
    }
}
