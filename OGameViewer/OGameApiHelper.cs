// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OGameApiHelper.cs" company="Me">
//   OGameApiHelper
// </copyright>
// <summary>
//   The o game api helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OGameViewer
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Serialization;

    using OGameViewer.BusinessObjects;

    /// <summary>
    /// The O Game Api Helper.
    /// </summary>
    public class OGameApiHelper
    {
        #region Instance

        private static OGameApiHelper instance;
        public static OGameApiHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OGameApiHelper();
                }

                return instance;
            }
        }

        #endregion

        #region OGame API Adresses

        /** JOUEURS **/

        private string PlayerStatuses
        {
            get
            {
                return string.Format("http://s{0}-fr.ogame.gameforge.com/api/players.xml", this.UniverseId);
            }
        }

        private string Position
        {
            get
            {
                return string.Format("http://s{0}-fr.ogame.gameforge.com/api/universe.xml", this.UniverseId);
            }
        }

        private string PlayerInfo
        {
            get
            {
                return string.Format("http://s{0}-fr.ogame.gameforge.com/api/playerData.xml?id={1}", this.UniverseId, this.PlayerId);
            }
        }

        /** CLASSEMENT **/

        private string PlayerRank
        {
            get
            {
                return string.Format("http://s{0}-fr.ogame.gameforge.com/api/highscore.xml?category=1&type=1", this.UniverseId);
            }
        }

        private string AllianceRank
        {
            get
            {
                return string.Format("http://s{0}-fr.ogame.gameforge.com/api/alliances.xml", this.UniverseId);
            }
        }

        private string RankTypes
        {
            get
            {
                return string.Format("http://s{0}-fr.ogame.gameforge.com/api/highscore.xml", this.UniverseId);
            }
        }

        /** OPTIONS **/

        private const string Servers = "http://s131-fr.ogame.gameforge.com/api/universes.xml";

        private string Traductions
        {
            get
            {
                return string.Format("http://s{0}-fr.ogame.gameforge.com/api/localization.xml", UniverseId);
            }
        }

        private string ServerOptions
        {
            get
            {
                return string.Format("http://s{0}-fr.ogame.gameforge.com/api/serverData.xml", this.UniverseId);
            }
        }

        private string UniverseId { get; set; }

        private string PlayerId { get; set; }

        #endregion

        #region Public Fields

        public ServerList ServerList { get; set; }

        public Players Players { get; set; }

        public List<ServerData> ServersData { get; set; }

        public List<playerData> PlayersData { get; set; }

        public Dictionary<string, string> RankTypesTranslations;

        public Dictionary<string, string> RankCategoryTranslations;

        #endregion

        #region CTOR

        private OGameApiHelper()
        {
            this.RankCategoryTranslations = new Dictionary<string, string>();
            this.RankCategoryTranslations.Add("0", "Player");
            this.RankCategoryTranslations.Add("1", "Alliance");
            this.RankTypesTranslations = new Dictionary<string, string>();
            this.RankTypesTranslations.Add("0", "Total");
            this.RankTypesTranslations.Add("1", "Economy");
            this.RankTypesTranslations.Add("2", "Research");
            this.RankTypesTranslations.Add("3", "Military");
            this.RankTypesTranslations.Add("4", "Military Built");
            this.RankTypesTranslations.Add("5", "Military Destroyed");
            this.RankTypesTranslations.Add("6", "Military Lost");
            this.RankTypesTranslations.Add("7", "Honor");
            this.LoadContext();
        }

        #endregion

        #region Public Methods

        public void LoadContext()
        {
            this.ServerList = this.GetFromApi<ServerList>(Servers);
            this.ServersData = new List<ServerData>();
            this.ServerList.Servers.ForEach(
                s =>
                    {
                        this.UniverseId = s.id;
                        this.ServersData.Add(this.GetFromApi<ServerData>(this.ServerOptions));
                    });
            this.UniverseId = null;
        }

        public void UpdateUniverseId(string universe)
        {
            this.UniverseId = this.ServersData.Single(s => s.Name == universe).Number;
            this.Players = this.GetFromApi<Players>(this.PlayerStatuses);
            this.PlayersData = new List<playerData>();
            this.Players.PlayerList.ForEach(
                p =>
                    {
                        this.PlayerId = p.Id;
                        this.PlayersData.Add(this.GetFromApi<playerData>(this.PlayerInfo));
                    });
            this.PlayerId = null;
        }

        #endregion

        #region Private Methods

        private IEnumerable<string> GetServerList()
        {
            var servers = this.GetFromApi<ServerList>(Servers);
            return servers.Servers.Select(s => s.id);
        }

        private T GetFromApi<T>(string link)
        {
            Stream stream;
            using (var wc = new WebClient())
            {
                if (Directory.Exists("data") == false)
                    Directory.CreateDirectory("data");
                string filename = "data/" + link.Replace("http://s", "").Replace("-fr.ogame.gameforge.com/api/", "").Replace(".xml", "").Replace("?id=", "").Replace("?category=1&type=1", "");

                if (File.Exists(filename) == true)
                {
                    stream = File.Open(filename, FileMode.Open);
                }
                else
                {
                    var data = wc.DownloadData(link);
                    FileStream fstream = File.Create(filename);
                    stream = new MemoryStream(data);
                    StreamWriter sw = new StreamWriter(fstream);
                    StreamReader sr = new StreamReader(stream);
                    sw.Write(sr.ReadToEnd());
                    sw.Close();
                    stream.Seek(0, SeekOrigin.Begin);
                }

            }

            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(stream);
        }

        #endregion
    }
}