﻿using Models;
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
    /// Interaction logic for EditTeamWindow.xaml
    /// </summary>
    public partial class EditTeamWindow : Window
    {
        Team team;
        private string token;
        public EditTeamWindow(Team team, string token)
        {
            this.team = team;
            this.token = token;
            
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(ESuppliers)))
            {
                Engine.Items.Add(item);
            }
            TName.Text = team.TName.ToString();
            Created.Text = team.Created.ToString();
            Country.Text = team.Country.ToString();
            Engine.Text = team.Engine.ToString();
        }

        private void EditTeam(object sender, RoutedEventArgs e)
        {
            team.TName = TName.Text;
            team.Created = int.Parse(Created.Text);
            team.Country = Country.Text;
            

            RestService restService = new RestService(ApiAddress.Address(), "/Team", token);
            restService.Put<string, Team>(team.TID, team);
            MainWindow mainWindow = new MainWindow();
            mainWindow.GetLeagueListNames();
            this.Close();
        }
    }
}
