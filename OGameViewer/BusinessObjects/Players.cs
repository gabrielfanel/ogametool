// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Players.cs" company="">
//   
// </copyright>
// <summary>
//   The players.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OGameViewer.BusinessObjects
{
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The players.
    /// </summary>
    [XmlRoot("players")]
    public class Players
    {
        [XmlElement("player")]
        public List<Player> PlayerList = new List<Player>();
    }

    public class Player
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlAttribute("alliance")]
        public string Alliance { get; set; }
    }

    [XmlRoot("playerData")]
    public class PlayerData
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("position")]
        public List<Rank> Position = new List<Rank>();

        [XmlElement("planets")]
        public List<Planet> Planets = new List<Planet>();
    }

    public class Rank
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("score")]
        public string Score { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class Planet
    {
        // ID NAME COORDS
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("coords")]
        public string Coords { get; set; }

        public Moon Moon { get; set; }
    }

    public class Moon
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("size")]
        public string Size { get; set; }
    }
}