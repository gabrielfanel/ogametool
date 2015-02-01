// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The main window view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OGameViewer
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using OGameViewer.Annotations;
    using OGameViewer.BusinessObjects;

    /// <summary>
    /// The main window view model.
    /// </summary>
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        #region Properties

        private IEnumerable<string> serverNames; 
        public IEnumerable<string> ServerNames
        {
            get
            {
                return this.serverNames;
            }

            set
            {
                this.serverNames = value;
                this.OnPropertyChanged("ServerNames");
            }
        }

        private string selectedUniverse;

        public string SelectedUniverse
        {
            get
            {
                return this.selectedUniverse;
            }

            set
            {
                this.selectedUniverse = value;
                OGameApiHelper.Instance.UpdateUniverseId(value);
                this.Players = new ObservableCollection<Player>(OGameApiHelper.Instance.Players.PlayerList);
                this.OnPropertyChanged("SelectedUniverse");
            }
        }

        private IEnumerable<Player> players; 
        public IEnumerable<Player> Players
        {
            get
            {
                return this.players;
            }

            set
            {
                this.players = value;
                this.OnPropertyChanged("Players");
            }
        }

        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get
            {
                return this.selectedPlayer;
            }

            set
            {
                this.selectedPlayer = value;
                this.OnPropertyChanged("SelectedPlayer");
                this.GetPlayerInfo();
            }
        }

        private string playerTotalPoints;

        public string PlayerTotalPoints
        {
            get
            {
                return this.playerTotalPoints;
            }

            set
            {
                this.playerTotalPoints = value;
                this.OnPropertyChanged("PlayerTotalPoints");
            }
        }

        private string playerTotalPointsRank;

        public string PlayerTotalPointsRank
        {
            get
            {
                return this.playerTotalPointsRank;
            }

            set
            {
                this.playerTotalPointsRank = value;
                this.OnPropertyChanged("PlayerTotalPointsRank");
            }
        }

        private string playerEconomyPoints;

        public string PlayerEconomyPoints
        {
            get
            {
                return this.playerEconomyPoints;
            }

            set
            {
                this.playerEconomyPoints = value;
                this.OnPropertyChanged("PlayerEconomyPoints");
            }
        }

        private string playerEconomyPointsRank;

        public string PlayerEconomyPointsRank
        {
            get
            {
                return this.playerEconomyPointsRank;
            }

            set
            {
                this.playerEconomyPointsRank = value;
                this.OnPropertyChanged("PlayerEconomyPointsRank");
            }
        }

        private string playerResearchPoints;

        public string PlayerResearchPoints
        {
            get
            {
                return this.playerResearchPoints;
            }

            set
            {
                this.playerResearchPoints = value;
                this.OnPropertyChanged("PlayerResearchPoints");
            }
        }

        private string playerResearchPointsRank;

        public string PlayerResearchPointsRank
        {
            get
            {
                return this.playerResearchPointsRank;
            }

            set
            {
                this.playerResearchPointsRank = value;
                this.OnPropertyChanged("PlayerResearchPointsRank");
            }
        }

        private string playerMilitaryPoints;

        public string PlayerMilitaryPoints
        {
            get
            {
                return this.playerMilitaryPoints;
            }

            set
            {
                this.playerMilitaryPoints = value;
                this.OnPropertyChanged("PlayerMilitaryPoints");
            }
        }

        private string playerMilitaryPointsRank;

        public string PlayerMilitaryPointsRank
        {
            get
            {
                return this.playerMilitaryPointsRank;
            }

            set
            {
                this.playerMilitaryPointsRank = value;
                this.OnPropertyChanged("PlayerMilitaryPointsRank");
            }
        }

        private string playerHonorPoints;

        public string PlayerHonorPoints
        {
            get
            {
                return this.playerHonorPoints;
            }

            set
            {
                this.playerHonorPoints = value;
                this.OnPropertyChanged("PlayerHonorPoints");
            }
        }

        private string playerHonorPointsRank;

        public string PlayerHonorPointsRank
        {
            get
            {
                return this.playerHonorPointsRank;
            }

            set
            {
                this.playerHonorPointsRank = value;
                this.OnPropertyChanged("PlayerHonorPointsRank");
            }
        }

        #endregion

        #region CTOR

        public MainWindowViewModel()
        {
            this.ServerNames = new List<string>(OGameApiHelper.Instance.ServersData.Select(this.GetServerName));
        }

        #endregion

        private string GetServerName(ServerData serverData)
        {
            if (!string.IsNullOrEmpty(serverData.Name))
            {
                return serverData.Name;
            }

            return string.Format("Server {0}", serverData.Number);
        }

        private void GetPlayerInfo()
        {
            if (this.SelectedPlayer == null)
            {
                return;
            }

            var playerInfo = OGameApiHelper.Instance.PlayersData.Single(p => p.Id == this.SelectedPlayer.Id);

            this.PlayerTotalPoints = playerInfo.Position.Single(pos => pos.Type == "0").Value;
            this.PlayerTotalPointsRank = playerInfo.Position.Single(pos => pos.Type == "0").Score;

            this.PlayerEconomyPoints = playerInfo.Position.Single(pos => pos.Type == "1").Value;
            this.PlayerEconomyPointsRank = playerInfo.Position.Single(pos => pos.Type == "1").Score;

            this.PlayerResearchPoints = playerInfo.Position.Single(pos => pos.Type == "2").Value;
            this.PlayerResearchPointsRank = playerInfo.Position.Single(pos => pos.Type == "2").Score;

            this.PlayerMilitaryPoints = playerInfo.Position.Single(pos => pos.Type == "3").Value;
            this.PlayerMilitaryPointsRank = playerInfo.Position.Single(pos => pos.Type == "3").Score;

            this.PlayerHonorPoints = playerInfo.Position.Single(pos => pos.Type == "7").Value;
            this.PlayerHonorPointsRank = playerInfo.Position.Single(pos => pos.Type == "7").Score;
        }

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}