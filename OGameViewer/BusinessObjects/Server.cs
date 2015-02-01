// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Server.cs" company="">
//   
// </copyright>
// <summary>
//   The server.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace OGameViewer.BusinessObjects
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// The server list.
    /// </summary>
    [XmlRoot("universes")]
    public class ServerList
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the servers.
        /// </summary>
        [XmlElement("universe")]
        public List<Server> Servers = new List<Server>();

        #endregion
    }

    /// <summary>
    ///     The server.
    /// </summary>
    public class Server
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the href.
        /// </summary>
        [XmlAttribute("href")]
        public string href { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlAttribute("id")]
        public string id { get; set; }

        #endregion
    }

    [XmlRoot("serverData")]
    public class ServerData
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("language")]
        public string Language { get; set; }

        [XmlElement("timezone")]
        public string Timezone { get; set; }

        [XmlElement("domain")]
        public string Domain { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("speed")]
        public string Speed { get; set; }

        [XmlElement("speedfleet")]
        public string SpeedFleet { get; set; }

        [XmlElement("galaxies")]
        public string Galaxies { get; set; }

        [XmlElement("systems")]
        public string Systems { get; set; }

        [XmlElement("acs")]
        public string Acs { get; set; }

        [XmlElement("rapidfire")]
        public string RapidFire { get; set; }

        [XmlElement("deftotf")]
        public string DefToTf { get; set; }

        [XmlElement("debrisfactor")]
        public string DebrisFactor { get; set; }

        [XmlElement("repairfactor")]
        public string RepairFactor { get; set; }

        [XmlElement("newbieprotectionlimit")]
        public string NewbieProtectionLimit { get; set; }

        [XmlElement("newbieprotectionhigh")]
        public string NewbieProtectionHigh { get; set; }

        [XmlElement("topscore")]
        public string TopScore { get; set; }

        [XmlElement("bonusfields")]
        public string BonusFields { get; set; }
    }
}