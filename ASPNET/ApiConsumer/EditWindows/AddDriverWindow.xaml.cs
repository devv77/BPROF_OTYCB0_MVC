using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApiConsumer
{
    /// <summary>
    /// Interaction logic for AddDriverWindow.xaml
    /// </summary>
    public partial class AddDriverWindow : Window
    {
        Team team;

        public AddDriverWindow(Team team)
        {
            this.team=team;
            InitializeComponent();
            
        }

        private void AddDriver(object sender, RoutedEventArgs e)
        {
            Driver driver = new Driver()
            {
                DName = DName.Text,
                TID = team.TID,
                BornYear = int.Parse(BornYear.Text),
                CountryB = CountryB.Text,
                RaceNumber = int.Parse(RaceNumber.Text),
                OwnTeam = team,                
            };
           
            RestService restService = new RestService(ApiAddress.Address(), "/Driver");
            restService.Post<Driver>(driver);
            MainWindow mainWindow = new MainWindow();
            mainWindow.GetLeagueListNames();
            
            this.Close();
        }
    }
}
