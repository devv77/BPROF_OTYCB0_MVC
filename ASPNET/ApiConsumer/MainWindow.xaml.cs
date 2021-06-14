using ApiConsumer.EditWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApiConsumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetLeagueListNames();
        }

        public async Task GetLeagueListNames()
        {

            RestService restService = new RestService(ApiAddress.Address(), "/League");
            
            IEnumerable<League> leaguelistnames = await restService.Get<League>();

            cbox.ItemsSource = null;
            cbox.ItemsSource = leaguelistnames;
            cbox.SelectedIndex=0;
        }

        private void cbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            League l = cbox.SelectedItem as League;
            lbox.ItemsSource = l.Teams.Select(t => t.TName);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetLeagueListNames();
        }

        private void lbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team t = lbox.SelectedItem as Team;
            lbox2.ItemsSource = t.Drivers.Select(d => d.DName);
        }

        private void AddLeagueClick(object sender, RoutedEventArgs e)
        {
            AddLeagueWindow addLeagueWindow = new AddLeagueWindow();
            addLeagueWindow.Show();

            
        }

        private void EditLeagueClick(object sender, RoutedEventArgs e)
        {
            EditLeagueWindow editLeagueWindow = new EditLeagueWindow(cbox.SelectedItem as League);
            editLeagueWindow.Show();

            
        }

        private void RemoveLeagueClick(object sender, RoutedEventArgs e)
        {
            if(cbox.SelectedItem as League !=null)
            {
                RestService restService = new RestService(ApiAddress.Address(), "/League");
                restService.Delete<string>((cbox.SelectedItem as League).LID);

                //update the list
                GetLeagueListNames();
            }
        }

        private void AddTeamClick(object sender, RoutedEventArgs e)
        {
            AddTeamWindow addTeamWindow = new AddTeamWindow(cbox.SelectedItem as League);
            addTeamWindow.Show();
            
        }

        private void EditTeamClick(object sender, RoutedEventArgs e)
        {
            EditTeamWindow editTeamWindow = new EditTeamWindow(lbox.SelectedItem as Team);
            editTeamWindow.Show();

            
        }

        private void RemoveTeamClick(object sender, RoutedEventArgs e)
        {
            if (lbox.SelectedItem as Team !=null)
            {
                RestService restService = new RestService(ApiAddress.Address(), "/Team");
                restService.Delete<string>((lbox.SelectedItem as Team).TID);

                GetLeagueListNames();
            }
        }

        private void AddDriverClick(object sender, RoutedEventArgs e)
        {
            AddDriverWindow addDriverWindow = new AddDriverWindow(lbox.SelectedItem as Team);
            addDriverWindow.Show();
            
        }

        private void EditDriverClick(object sender, RoutedEventArgs e)
        {
            EditDriverWindow editDriverWindow = new EditDriverWindow(lbox2.SelectedItem as Driver);
            editDriverWindow.Show();
            
        }

        private void RemoveDriverClick(object sender, RoutedEventArgs e)
        {
            if (lbox2.SelectedItem as Driver != null)
            {
                RestService restService = new RestService(ApiAddress.Address(), "/Driver");
                restService.Delete<string>((lbox2.SelectedItem as Driver).DID);

                //update the list
                GetLeagueListNames();
            }
        }
    }
}
