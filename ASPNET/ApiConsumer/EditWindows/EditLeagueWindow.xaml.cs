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

namespace ApiConsumer.EditWindows
{
    /// <summary>
    /// Interaction logic for EditLeagueWindow.xaml
    /// </summary>
    public partial class EditLeagueWindow : Window
    {
        League league;
        private string token;
        public EditLeagueWindow(League league, string token)
        {
            this.league = league;
            this.token = token;
            
            InitializeComponent();
            Name.Text = league.Name;
            Rating.Text = league.Rating.ToString();
            RaceTypes.SelectedItem = league.RaceTypes.ToString();
        }

        private void EditLeague(object sender, RoutedEventArgs e)
        {
            league.Name = Name.Text;
            league.Rating = int.Parse(Rating.Text);
            //league.RaceTypes = RaceTypes.SelectedItem;

            RestService restService = new RestService(ApiAddress.Address(), "/League", token);
            restService.Put<string, League>(league.LID, league);
            MainWindow mainWindow = new MainWindow();
            mainWindow.GetLeagueListNames();
            this.Close();

        }
    }
}
