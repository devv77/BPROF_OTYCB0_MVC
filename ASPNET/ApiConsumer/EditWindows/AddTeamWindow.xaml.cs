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
    /// Interaction logic for AddTeamWindow.xaml
    /// </summary>
    public partial class AddTeamWindow : Window
    {

        League league=new League();
        public AddTeamWindow(League league)
        {
            this.league = league;
            InitializeComponent();
        }

        private void AddTeam(object sender, RoutedEventArgs e)
        {
            Team team = new Team()
            {
                TName = TName.Text,
                Created = int.Parse(Created.Text),
                Country = Country.Text,
                //Engine = Engine.Text,
                LID = league.LID,
                League = league
            };

            RestService restService = new RestService(ApiAddress.Address(), "/Team");
            restService.Post<Team>(team);
            MainWindow mainWindow = new MainWindow();
            mainWindow.GetLeagueListNames();
            this.Close();

        }
    }
}
