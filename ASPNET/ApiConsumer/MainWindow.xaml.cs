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
            RestService restService = new RestService("https://localhost:5001/", "/League");
            
            IEnumerable<League> leaguelistnames = await restService.Get<League>();

            cbox.ItemsSource = null;
            cbox.ItemsSource = leaguelistnames;
            cbox.SelectedIndex = 0;
        }

        private void cbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            League l = cbox.SelectedItem as League;
            lbox.ItemsSource = l.Teams.Select(t => t.TName);
        }

        private void cbox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
