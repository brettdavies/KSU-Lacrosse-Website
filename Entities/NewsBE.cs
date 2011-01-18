using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSULax.Entities
{
    public class NewsBE
    {
        private string _title;
        private string _titlePath;

        /// <summary>
        /// Date for a news story
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Title of a news story
        /// </summary>
        public string Title
        {
            get
            {
                return _title.Trim();
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// Path element of a news story
        /// </summary>
        public string TitlePath
        {
            get
            {
                return _titlePath.ToLower();
            }

            set
            {
                _titlePath = value;
            }
        }
        
        /// <summary>
        /// Text of news story
        /// </summary>
        public string Story { get; set; }

        /// <summary>
        /// Author of a news story
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Source of a news story
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// URL of the source of a news story
        /// </summary>
        public string SourceUrl { get; set; }
    }
}