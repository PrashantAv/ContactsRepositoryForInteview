using System.ComponentModel.DataAnnotations;

namespace ContactProject.Models
{
    #region contact Model...
    /// <summary>
    /// contact Model Class, purposely used for populating views and carry data from database.
    /// </summary>
    public class ContactModel
    {
        #region Automated Properties
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EMail { get; set; }

        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone Number is not valid")]
        public string PhoneNo { get; set; }

        public bool Status { get; set; } 
        #endregion
    } 
    #endregion
}