﻿using Cinema_Management_System.Command;
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

            //Films = new ObservableCollection<Film>(FakeRepo.getAll());
            BackButtonClick = new RelayCommand((s) =>
            {
                ClassHelper.viewfilm.Close();
                userWindow = new UserWindow();
                userWindow.ShowDialog();

            });

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) =>
            {
                ClassHelper.Film.Time = new List<string>();
                SelectedFilmUserControl selected = new SelectedFilmUserControl();
                
                selected.FilmNameTextBlock.Text = ClassHelper.Film.Name;
                selected.DescriptiontextBlock.Text = ClassHelper.Film.Description;
                selected.selectImage.Source = new BitmapImage(new Uri(
                 ClassHelper.Film.ImagePath, UriKind.RelativeOrAbsolute));
                //selected.Timestxtblock.Text = ClassHelper.Film.Time[0];
                ClassHelper.Film = Film;
                ClassHelper.viewfilm.mGrid.Children.Add(selected);



            });
            searchButtonClick = new RelayCommand((ss) =>
            {
                ClassHelper.Film = new Film();
                try
                {
                    Film = new Film();
                    Films = new ObservableCollection<Film>();
                    HttpResponseMessage response = new HttpResponseMessage();
                    response =
                                          http.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&s={viewFilmsWindow.SearchtxtBox.Text}&plot=full").Result;
                    var str = response.Content.ReadAsStringAsync().Result;
                    Data = JsonConvert.DeserializeObject(str);
                    response =
                                              http.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&t={Data.Search[0].Title}&plot=full").Result;
                    str = response.Content.ReadAsStringAsync().Result;
                    SingleData = JsonConvert.DeserializeObject(str);

                    ImagePath = SingleData.Poster;
                    Minute = SingleData.Runtime;
                    Description = SingleData.Genre;

                    viewFilmsWindow.FilmImage.Source = new BitmapImage(new Uri(
                    ImagePath, UriKind.RelativeOrAbsolute));
                    viewFilmsWindow.FilmNameTextBloxk.Text = SingleData.Title;
                    ClassHelper.Film.Name = SingleData.Title;
                    ClassHelper.Film.ImagePath = SingleData.Poster;
                    ClassHelper.Film.Description = SingleData.Genre;
                    ClassHelper.Film.Time=SingleData.RunTime;
                }
                catch (Exception ex)
                {

                }
               

            });
        }
    }
}
