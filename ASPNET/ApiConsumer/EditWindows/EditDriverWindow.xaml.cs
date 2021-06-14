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
    /// Interaction logic for EditDriverWindow.xaml
    /// </summary>
    public partial class EditDriverWindow : Window
    {
        Driver driver;
        private string token;
        public EditDriverWindow(Driver driver, string token)
        {
            this.driver = driver;
            this.token = token;
            DName.Text = driver.DName;
            BornYear.Text = driver.BornYear.ToString();
            CountryB.Text = driver.CountryB;
            RaceNumber.Text = driver.RaceNumber.ToString();
            InitializeComponent();
        }

        private void EditDriver(object sender, RoutedEventArgs e)
        {
            driver.DName = DName.Text;
            driver.BornYear = int.Parse(BornYear.Text);
            driver.CountryB = CountryB.Text;
            driver.RaceNumber = int.Parse(RaceNumber.Text);

            RestService restService = new RestService(ApiAddress.Address(), "/Driver", token);
            restService.Put<string, Driver>(driver.DID, driver);

            MainWindow mainWindow = new MainWindow();
            mainWindow.GetLeagueListNames();
            this.Close();
        }
    }
}
