using System;
using System.ComponentModel.DataAnnotations;

namespace AdminUser.Models
{
    public class AdminInputFormModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [Display(Name = "Race/Ethnicity")]
        public string Ethnicity { get; set; }

        [Required]
        [Display(Name = "Cell Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Institution/School/Youth Group and Subgroup or Team")]
        public string Institution { get; set; }

        [Display(Name = "Participants' Knowledge and Experience with Finances")]
        public string Knowledge { get; set; }

        [Display(Name = "Amount Participant has in Savings")]
        public string Savings { get; set; }

        [Display(Name = "Upload Screenshot of Savings")]
        public string Screenshot { get; set; }

        [Display(Name = "Did Participant Open a Bank Account?")]
        public string BankAccount { get; set; }

        [Display(Name = "How Often is a Bank Account Used")]
        public string BankUsage { get; set; }

        [Display(Name = "New Financial Conversations")]
        public string Conversations { get; set; }

        [Display(Name = "Financial Habits Implemented")]
        public string Habits { get; set; }

        [Display(Name = "Additional Steps Taken")]
        public string Steps { get; set; }

        [Display(Name = "Personal S.M.A.R.T. Financial Goal")]
        public string Goal { get; set; }
    }
}