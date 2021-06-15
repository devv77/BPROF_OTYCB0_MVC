using Models;
using System;
using System.Windows;

namespace ApiConsumer.EditWindows
{
    /// <summary>
    /// Interaction logic for AddTeamWindow.xaml
    /// </summary>
    public partial class AddTeamWindow : Window
    {
        private League league = new League();
        private string token;

        public AddTeamWindow(League league, string token)
        {
            this.league = league;
            this.token = token;

            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(ESuppliers)))
            {
                Engine.Items.Add(item);
            }
        }

        private void AddTeam(object sender, RoutedEventArgs e)
        {
            Team team = new Team()
            {
                TName = TName.Text,
                Created = int.Parse(Created.Text),
                Country = Country.Text,
                //Engine = Engine.SelectedItem,
                LID = league.LID,
                League = league
            };

            RestService restService = new RestService(ApiAddress.Address(), "/Team", token);
            restService.Post<Team>(team);
            MainWindow mainWindow = new MainWindow();
            mainWindow.GetLeagueListNames();
            this.Close();
        }
    }
}