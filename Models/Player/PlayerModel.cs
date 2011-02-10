using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;

namespace KSULax.Models.Player
{
    public class PlayerBioModel
    {
        public PlayerModel PlayerInfo { get; set; }
        public PlayerGameStatListModel PlayerStatList { get; set; }
        public PlayerAwardModelList PlayerAwardList { get; set; }
    }

    public class PlayerModel
    {
        public PlayerModel(PlayerBE player)
        {
            Bio = player.Bio;
            Captain = player.Captain;
            ClassYr = player.ClassYr;
            EligibilityYr = player.EligibilityYr;
            FirstName = player.FirstName;
            Height = player.Height;
            HighSchool = player.HighSchool;
            HomeState = player.HomeState;
            Hometown = player.Hometown;
            JerseyNum = player.JerseyNum;
            LastName = player.LastName;
            Major = player.Major;
            MiddleName = player.MiddleName;
            Officer = player.Officer;
            PlayerID = player.PlayerID;
            Position = player.Position;
            President = player.President;
            SeasonID = player.SeasonID;
            Weight = player.Weight;
        }

        public string Bio { get; set; }

        /// <summary>
        /// True if the player is a team captain that season.
        /// </summary>
        public bool Captain { get; set; }

        public string ClassYr { get; set; }
        public string EligibilityYr { get; set; }
        public string FirstName { get; set; }
        public int Height { get; set; }
        public string HighSchool { get; set; }
        public string HomeState { get; set; }
        public string Hometown { get; set; }
        public int JerseyNum { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public string MiddleName { get; set; }

        /// <summary>
        /// True if the player is a club officer that season.
        /// </summary>
        public bool Officer { get; set; }
        
        public int PlayerID { get; set; }
        public string Position { get; set; }

        /// <summary>
        /// True if the player is club president that season.
        /// </summary>
        public bool President { get; set; }
        
        public int SeasonID { get; set; }
        public int Weight { get; set; }
        
        /// <summary>
        /// Returns the players Hometown and HomeState.
        /// </summary>
        public string Home
        {
            get
            {
                if(!string.IsNullOrEmpty(Hometown) && !string.IsNullOrEmpty(HomeState))
                {
                    return Hometown + ", " + HomeState;;
                }
                else if(string.IsNullOrEmpty(Hometown) && !string.IsNullOrEmpty(HomeState))
                {
                    return HomeState;
                }
                else if (!string.IsNullOrEmpty(Hometown) && string.IsNullOrEmpty(HomeState))
                {
                    return Hometown;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Returns the players FullName.
        /// </summary>
        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }

        /// <summary>
        /// Returns a URL friendly version of the player's FullName.
        /// </summary>
        public string FullNameURL
        {
            get
            {
                return (FullName.Replace(" ","-")).ToLower();
            }
        }

        public string ImagePath()
        {
            string imagePath = "/content/images/players/" + PlayerID + ".png";
            //if (! System.IO.File.Exists(MapPath(imagePath)))
            //{
            //    imagePath = "/content/images/teams/kennesaw_state_128.png";
            //}
            return imagePath;
        }

        /// <summary>
        /// Returns the players height (X"Y') based on their height in inches from their most recent season.
        /// </summary>
        public string HeightFeet
        {
            get
            {
                return ((Height / 12) + "&#39;" + (Height - (Height / 12 * 12)) + "&quot;");
            }
        }

        /// <summary>
        /// Returns True if the player is a current player and False otherwise.
        /// </summary>
        public bool isCurPlayer
        {
            get
            {
                if (SeasonID.Equals(KSU.maxPlayerSeason))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}