using Logic;
using Models;
using Moq;
using NUnit.Framework;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        public Mock<IRepository<League>> leagueRepo;
        public Mock<IRepository<Team>> teamRepo;
        public Mock<IRepository<Driver>> driverRepo;

        [SetUp]
        public void Setup()
        {
            leagueRepo = new Mock<IRepository<League>>();
            teamRepo = new Mock<IRepository<Team>>();
            driverRepo = new Mock<IRepository<Driver>>();

            List<League> leagues = new List<League>()
            {
                new League() {LID = Guid.NewGuid().ToString(), Name = "Formula 1 (F1)", Rating = 8, Homology = true, RaceTypes = RaceType.circuit},
                new League() { LID = Guid.NewGuid().ToString(), Name = "World Touring Car Championship (WTCC)", Rating = 7, Homology = false, RaceTypes = RaceType.circuit },

            };

            List<Team> teams = new List<Team>()
            {
                new Team { TID = Guid.NewGuid().ToString(), TName = "Mercedes-AMG Petronas F1 Team", Created = 2010, Country = "Germany", Engine = ESuppliers.Mercedes, LID = leagues.ElementAt(0).LID },
                new Team { TID = Guid.NewGuid().ToString(), TName = "Aston Martin Red Bull Racing", Created = 2005, Country = "Austria", Engine = ESuppliers.Honda, LID = leagues.ElementAt(0).LID },
                new Team { TID = Guid.NewGuid().ToString(), TName = "Renault DP World F1 Team", Created = 1977, Country = "France", Engine = ESuppliers.Renault, LID = leagues.ElementAt(0).LID },
                new Team { TID = Guid.NewGuid().ToString(), TName = "Zengő Motorsport Services KFT", Created = 1996, Country = "Hungary", Engine = ESuppliers.Seat, LID = leagues.ElementAt(1).LID },
            };

            List<Driver> drivers = new List<Driver>()
            {
                new Driver { DID = Guid.NewGuid().ToString(), DName = "Valtteri Bottas", BornYear = 1989, CountryB = "Finland", RaceNumber = 77, TID = teams.ElementAt(0).TID },
                new Driver { DID = Guid.NewGuid().ToString(), DName = "Daniel Ricciardo", BornYear = 1989, CountryB = "Australia", RaceNumber = 3, TID = teams.ElementAt(2).TID },
                new Driver { DID = Guid.NewGuid().ToString(), DName = "Max Verstappen", BornYear = 1997, CountryB = "Belgium", RaceNumber = 33, TID = teams.ElementAt(1).TID },
                new Driver { DID = Guid.NewGuid().ToString(), DName = "Boldizs Bence", BornYear = 1997, CountryB = "Hungary", RaceNumber = 55, TID = teams.ElementAt(3).TID },
            };

            leagueRepo.Setup(x => x.Search()).Returns(leagues.AsQueryable());
            teamRepo.Setup(x => x.Search()).Returns(teams.AsQueryable());
            driverRepo.Setup(x => x.Search()).Returns(drivers.AsQueryable());
        }

        [Test]
        public void TestAddNewLeague()
        {
            LeagueLogic l = new LeagueLogic(this.leagueRepo.Object);
            League newL = new League()
            {
                LID = Guid.NewGuid().ToString(),
                Name = "TestLeague",
                Rating = 5,
                Homology = true,
                RaceTypes = RaceType.sprint
            };

            leagueRepo.Setup(x => x.AddItem(It.IsAny<League>()));
            l.AddLeague(newL);
            leagueRepo.Verify(x => x.AddItem(newL), Times.Once);
        }
        [Test]
        public void TestDeleteLeague()
        {
            LeagueLogic l = new LeagueLogic(this.leagueRepo.Object);
            League newL = new League()
            {
                LID = Guid.NewGuid().ToString(),
                Name = "TestLeague",
                Rating = 5,
                Homology = true,
                RaceTypes = RaceType.sprint
            };
            leagueRepo.Setup(x => x.Delete(It.IsAny<League>()));
            l.DeleteLeague(newL.LID);
            leagueRepo.Verify(x => x.Delete(newL.LID), Times.Once);
        }
        [Test]
        public void TestUpdateLeague()
        {
            LeagueLogic l = new LeagueLogic(this.leagueRepo.Object);
            League newL = new League()
            {
                LID = Guid.NewGuid().ToString(),
                Name = "TestLeague",
                Rating = 5,
                Homology = true,
                RaceTypes = RaceType.sprint
            };
            leagueRepo.Setup(x => x.Update(newL.LID, It.IsAny<League>()));
            l.UpdateLeague(newL.LID, newL);
            leagueRepo.Verify(x => x.Update(newL.LID, It.IsAny<League>()), Times.Once);
        }
        [Test]
        public void TestListAllLeague()
        {
            LeagueLogic l = new LeagueLogic(this.leagueRepo.Object);
            List<League> newL = new List<League>()
            {
                new League {LID = Guid.NewGuid().ToString(), Name = "TestLeague", Rating = 5, Homology = true, RaceTypes = RaceType.sprint },
                new League {LID = Guid.NewGuid().ToString(), Name = "TestLeague2", Rating = 3, Homology = false, RaceTypes = RaceType.circuit}
            };

            List<League> expectedoutput = new List<League>()
            {
                newL[0],newL[1]
            };

            leagueRepo.Setup(x => x.Search()).Returns(newL.AsQueryable());
            var output = l.GetLeagues();
            Assert.That(output, Is.EquivalentTo(expectedoutput));
            Assert.That(output.Count, Is.EqualTo(expectedoutput.Count));
        }
        /*-----------------------------------------------------------------------------------------------------------------*/
        [Test]
        public void TestAddNewTeam()
        {
            TeamLogic t = new TeamLogic(this.teamRepo.Object);
            Team newt = new Team()
            {
                TID = Guid.NewGuid().ToString(),
                TName = "TestTeam",
                Created = 1999,
                Country = "TestCountry",
                Engine = ESuppliers.Audi,
                LID = Guid.NewGuid().ToString()
            };

            teamRepo.Setup(x => x.AddItem(It.IsAny<Team>()));
            t.AddTeam(newt);
            teamRepo.Verify(x => x.AddItem(newt), Times.Once);
        }
        [Test]
        public void TestDeleteTeam()
        {
            TeamLogic t = new TeamLogic(this.teamRepo.Object);
            Team newt = new Team()
            {
                TID = Guid.NewGuid().ToString(),
                TName = "TestTeam",
                Created = 1999,
                Country = "TestCountry",
                Engine = ESuppliers.Audi,
                LID = Guid.NewGuid().ToString()
            };

            teamRepo.Setup(x => x.Delete(It.IsAny<Team>()));
            t.DeleteTeam(newt);
            teamRepo.Verify(x => x.Delete(newt), Times.Once);
        }
        [Test]
        public void TestUpdateTeam()
        {
            TeamLogic t = new TeamLogic(this.teamRepo.Object);
            Team newt = new Team()
            {
                TID = Guid.NewGuid().ToString(),
                TName = "TestTeam",
                Created = 1999,
                Country = "TestCountry",
                Engine = ESuppliers.Audi,
                LID = Guid.NewGuid().ToString()
            };

            teamRepo.Setup(x => x.Update(newt.TID, It.IsAny<Team>()));
            t.UpdateTeam(newt.TID, newt);
            teamRepo.Verify(x => x.Update(newt.TID, It.IsAny<Team>()), Times.Once);
        }
        [Test]
        public void TestListAllTeams()
        {
            TeamLogic t = new TeamLogic(this.teamRepo.Object);
            List<Team> newT = new List<Team>()
            {
                new Team {LID = Guid.NewGuid().ToString(), TID = Guid.NewGuid().ToString(), TName = "TestTeam", Created = 1995, Country="TestC", Engine=ESuppliers.Audi},
                new Team {LID = Guid.NewGuid().ToString(), TID = Guid.NewGuid().ToString(), TName = "TestTeam2", Created = 1995, Country="TestC2", Engine=ESuppliers.Mercedes}
            };

            List<Team> expectedoutput = new List<Team>()
            {
                newT[0],newT[1]
            };

            teamRepo.Setup(x => x.Search()).Returns(newT.AsQueryable());
            var output = t.GetAllTeam();
            Assert.That(output, Is.EquivalentTo(expectedoutput));
            Assert.That(output.Count, Is.EqualTo(expectedoutput.Count));
        }
        /*-----------------------------------------------------------------------------------------------------------------*/
        [Test]
        public void TestAddNewDriver()
        {
            DriverLogic d = new DriverLogic(this.driverRepo.Object);
            Driver newd = new Driver()
            {
                TID = Guid.NewGuid().ToString(),
                DID = Guid.NewGuid().ToString(),
                DName = "TestDriver",
                BornYear = 1999,
                CountryB = "TestCountry",
                RaceNumber = 1,                
            };

            driverRepo.Setup(x => x.AddItem(It.IsAny<Driver>()));
            d.AddDriver(newd);
            driverRepo.Verify(x => x.AddItem(newd), Times.Once);
        }
        [Test]
        public void TestDeleteDriver()
        {
            DriverLogic d = new DriverLogic(this.driverRepo.Object);
            Driver newd = new Driver()
            {
                TID = Guid.NewGuid().ToString(),
                DID = Guid.NewGuid().ToString(),
                DName = "TestDriver",
                BornYear = 1999,
                CountryB = "TestCountry",
                RaceNumber = 1,
            };

            driverRepo.Setup(x => x.Delete(It.IsAny<Driver>()));
            d.DeleteDriver(newd);
            driverRepo.Verify(x => x.Delete(newd), Times.Once);
        }
        [Test]
        public void TestUpdateDriver()
        {
            DriverLogic d = new DriverLogic(this.driverRepo.Object);
            Driver newd = new Driver()
            {
                TID = Guid.NewGuid().ToString(),
                DID = Guid.NewGuid().ToString(),
                DName = "TestDriver",
                BornYear = 1999,
                CountryB = "TestCountry",
                RaceNumber = 1,
            };

            driverRepo.Setup(x => x.Update(newd.DID, It.IsAny<Driver>()));
            d.UpdateDriver(newd.DID, newd);
            driverRepo.Verify(x => x.Update(newd.DID, It.IsAny<Driver>()), Times.Once);
        }
        [Test]
        public void TestListAllDriver()
        {
            DriverLogic d = new DriverLogic(this.driverRepo.Object);
            List<Driver> newD = new List<Driver>()
            {
                new Driver {DID = Guid.NewGuid().ToString(), TID = Guid.NewGuid().ToString(), DName = "TestTeam", BornYear= 1995, CountryB="TestC", RaceNumber=1},
                new Driver {DID = Guid.NewGuid().ToString(), TID = Guid.NewGuid().ToString(), DName = "TestTeam2", BornYear= 1995, CountryB="TestC2", RaceNumber=2}
            };

            List<Driver> expectedoutput = new List<Driver>()
            {
                newD[0],newD[1]
            };

            driverRepo.Setup(x => x.Search()).Returns(newD.AsQueryable());
            var output = d.GetDrivers();
            Assert.That(output, Is.EquivalentTo(expectedoutput));
            Assert.That(output.Count, Is.EqualTo(expectedoutput.Count));
        }
        /*------------------------------------------------------------------------------------------------------------------------------------------------------*/



    }
}
