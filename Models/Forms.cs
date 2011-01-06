using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace KSULax.Models
{
    public class MessageModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    #region FormTemplate
    /// <summary>
    /// Template Class for forms. Provides required field checking.
    /// </summary>
    public class FormTemplateModel : IDataErrorInfo
    {
        /// <summary>
        /// Used to store errors. Format is ([Column name], [Error message])
        /// </summary>
        protected Dictionary<string, string> _errors = new Dictionary<string, string>();

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
    }
    #endregion FormTemplate

    #region ContactUsForm
    public class ContactUsFormModel : FormTemplateModel
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
    }
    #endregion ContactUsForm

    #region PlayerRegistrationForm
    public class PlayerRegistrationModel : FormTemplateModel
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

        private string _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _firstname = value; }
                else
                { _errors.Add("FirstName", "'First Name' is required."); }
            }
        }

        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _lastname = value; }
                else
                { _errors.Add("LastName", "'Last Name' is required."); }
            }
        }

        private string _phonenumber;
        public string PhoneNumber
        {
            get { return _phonenumber; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _phonenumber = value; }
                else
                { _errors.Add("PhoneNumber", "'Phone Number' is required."); }
            }
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

        private string _uslaxid;
        public string USLaxID
        {
            get { return _uslaxid; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _uslaxid = value; }
                else
                { _errors.Add("USLaxID", "'USLacrosse ID' is required."); }
            }
        }

        private string _ksuid;
        public string KSUID
        {
            get { return _ksuid; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _ksuid = value; }
                else
                { _errors.Add("KSUID", "'KSU ID' is required."); }
            }
        }

        private string _major;
        public string Major
        {
            get { return _major; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _major = value; }
                else
                { _errors.Add("Major", "'Major' is required."); }
            }
        }

        private string _gpa;
        public string GPA
        {
            get { return _gpa; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _gpa = value; }
                else
                { _errors.Add("GPA", "'GPA' is required."); }
            }
        }

        private string _height;
        public string Height
        {
            get { return _height; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _height = value; }
                else
                { _errors.Add("Height", "'Height' is required."); }
            }
        }

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _weight = value; }
                else
                { _errors.Add("Weight", "'Weight' is required."); }
            }
        }

        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _position = value; }
                else
                { _errors.Add("Position", "'Position' is required."); }
            }
        }

        private string _hometown;
        public string Hometown
        {
            get { return _hometown; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _hometown = value; }
                else
                { _errors.Add("Hometown", "'Hometown' is required."); }
            }
        }

        private string _homestate;
        public string Homestate
        {
            get { return _homestate; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _homestate = value; }
                else
                { _errors.Add("Homestate", "'Homestate' is required."); }
            }
        }

        private string _highschool;
        public string Highschool
        {
            get { return _highschool; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _highschool = value; }
                else
                { _errors.Add("Highschool", "'Highschool' is required."); }
            }
        }

        private string _highschoolyear;
        public string Highschoolyear
        {
            get { return _highschoolyear; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                { _highschoolyear = value; }
                else
                { _errors.Add("Highschoolyear", "'Highschool Year' is required."); }
            }
        }
    }
    #endregion PlayerRegistrationForm
}