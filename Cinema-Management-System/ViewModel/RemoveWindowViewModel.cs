using Cinema_Management_System.Command;
using Cinema_Management_System.Models;
using Cinema_Management_System.Repository;
using Cinema_Management_System.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModel
{
    public class RemoveWindowViewModel:BaseViewModel
    {
        public RelayCommand DeleteButtonCommand { get; set; }
        public RelayCommand SelectedFilmCommand { get; set; }
        public RelayCommand BackButtonCommand { get; set; }
        public ObservableCollection<Film> Films { get; set; } = new ObservableCollection<Film>();
        public RemoveWindowViewModel(RemoveWindow removeWindow)
        {
            Films = FakeRepo.Films;
            BackButtonCommand = new RelayCommand((r) =>
            {

                removeWindow.Close();

            });
            DeleteButtonCommand = new RelayCommand((d) =>
            {
                    var film = removeWindow.mainListbox.SelectedItem as Film;
                    FakeRepo.Films.Remove(film);
                

            });
            
        }
    }

    
}
