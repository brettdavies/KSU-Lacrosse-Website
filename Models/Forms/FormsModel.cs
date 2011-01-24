using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Web.Mvc;

namespace KSULax.Models
{
    public class MessageModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    /// <summary>
    /// Provides a Validator for Email Address fields.
    /// </summary>
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object address)
        {
            if (address == null)
            {
                return true;
            }
            try
            {
                address = new MailAddress(address.ToString()).Address;
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }
    }

    public class EmailValidator : DataAnnotationsModelValidator<EmailAttribute>
    {
        string _message;

        public EmailValidator(ModelMetadata metadata, ControllerContext context, EmailAttribute attribute)
            : base(metadata, context, attribute)
        {
            _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule>
         GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "email"
            };
            return new[] { rule };
        }
    }

    /// <summary>
    /// Class used on the Contact Us Form
    /// </summary>
    public class ContactUsFormModel
    {
        [Required(ErrorMessage = "Subject is Required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)+$", ErrorMessage = "First and Last Name are Required")]
        public string Name { get; set; }

        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [Email(ErrorMessage = "Not a valid email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is Required.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "A Message is Required.")]
        public string Comments { get; set; }
    }

    /// <summary>
    /// Class used on the Player Registration Form
    /// </summary>
    public class PlayerRegistrationModel
    {
        public string Subject { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string USLaxID { get; set; }

        public string KSUID { get; set; }

        public string Major { get; set; }

        public string GPA { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string Position { get; set; }

        public string Hometown { get; set; }

        public string Homestate { get; set; }

        public string Highschool { get; set; }

        public string Highschoolyear { get; set; }
    }
}