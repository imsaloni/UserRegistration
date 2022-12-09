using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace UserRegistration.Models
{
    public class User
    {
        [Key]
        [Display(Name = "RegistrationId")]
        public int RegistrationId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "FatherName")]
        public string FatherName{ get; set; }
        [Required]
        [Display(Name = "MobileNumber")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [Display (Name ="EmailId")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email is not valid")]
        public string EmailID { get; set; }
        [Required]
        [Display(Name = "AdharcardNumber")]
        public string AdharcardNumber { get; set; }
        [Required(ErrorMessage = "Field Should not be Empty")]
        [Display(Name = "DateOfBirth")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString ="{0:dd/MMM/yyyy}")]
        public string DateOfBirth { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set;}
        [Required]
        public string Landmark { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string City{ get; set; }
        [Required]
        public int Pincode { get; set; }
        [Required]
        public string OccupationType { get; set; }
        [Required]
        public string SourceOfIncome { get; set; }
        [Required]
        public string GrossAnnualIncome { get; set; }
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}