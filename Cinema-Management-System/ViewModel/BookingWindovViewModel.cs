using Cinema_Management_System.Command;
using Cinema_Management_System.Extentesion;
using Cinema_Management_System.Models;
using Cinema_Management_System.View;
using System.Windows.Controls;

namespace Cinema_Management_System.ViewModel
{
    public class BookingWindovViewModel : BaseViewModel
    {
        public RelayCommand BookSeatButtonCommand { get; set; }
        public RelayCommand BackBtnCommand { get; set; }
        public RelayCommand ButtonClick { get; set; }
        public RelayCommand SelectedTimeChangedCommand { get; set; }
        public RelayCommand ShowHistoryButtonCommand { get; set; }
        private Film film;
        public string Time { get; set; }
        private bool hasClicked;
        public bool HasClicked
        {
            get => hasClicked; set
            {
                hasClicked = value;
                OnPropertyChanged();

            }
        }
        public Film Film
        {
            get { return film; }
            set { film = value; OnPropertyChanged(); }
        }
        private Button button;

        public Button Button
        {
            get { return button; }
            set { button = value; OnPropertyChanged(); }
        }


        public BookingWindovViewModel(BookingWindow bookingWindow)
        {
            Film = ClassHelper.Film;
            BackBtnCommand = new RelayCommand((b) =>
            {
                ClassHelper.BookingVindow.Close();
                UserWindow userWindow = new UserWindow();
                userWindow.ShowDialog();

            });
            SelectedTimeChangedCommand = new RelayCommand((s) =>
            {
                bookingWindow.FilmComboBox1.ItemsSource = ClassHelper.Film.Time;


            });
            ButtonClick = new RelayCommand((bc) =>
            {
                HasClicked = !HasClicked;
                //    Button button = new Button();
                //    button = (Button)bc;

                //typecast;

            });

            BookSeatButtonCommand = new RelayCommand((bs) =>
            {
                ClassHelper.BookingVindow.Close();

                TicketWindow ticketWindow1 = new TicketWindow();
                ticketWindow1.UserNametxtblock.Text =MainVindowViewModel.DataBase.Users[0].Name;
                ticketWindow1.FilmTxtBlock.Text = MainVindowViewModel.DataBase.Films[0].Name;
                 
                ticketWindow1.ShowDialog();
                bookingWindow.Close();

            });
        }

    }
}
