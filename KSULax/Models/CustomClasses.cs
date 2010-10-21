using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace KSULax.Models
{
    public class HomepageData
    {
        public List<Game> games { get; set; }
        public List<News> news { get; set; }
    }

    public class RosterData
    {
        public List<Game> games { get; set; }
        public List<PlayerSeason> players { get; set; }
    }

    public class Ranking
    {
        public short pollSource { get; set; }
        public DateTime date { get; set; }
        public string datestr { get; set; }
        public short rank { get; set; }
        public string rankUrl { get; set; }
    }

    #region Email
    public class MessageModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
    public class EmailModel : IDataErrorInfo
    {
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _subject = value; }
                else
                { _errors.Add("Subject", "'Subject' is required."); }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _name = value; }
                else
                { _errors.Add("Name", "'Name' is required."); }
            }
        }

        private string _companyname;
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _email = value; }
                else
                { _errors.Add("Email", "'Email' is required."); }
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _phone = value; }
                else
                { _errors.Add("Phone", "'Phone' is required."); }
            }
        }

        private string _comments;
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _comments = value; }
                else
                { _errors.Add("Comments", "'Comments' is required."); }
            }
        }

        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        #region IDataErrorInfo Members

        public string Error
        { get { return null; } }

        public string this[string columnName]
        {
            get
            {
                string error;
                if (_errors.TryGetValue(columnName, out error))
                { return error; }
                else
                { return null; }
            }
        }
        #endregion
    }
    #endregion Email
}
