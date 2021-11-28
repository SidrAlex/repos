using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UserRegistrationApp.EFEntity.Models
{
    public class User
    {
        //Primary key
        public int Id { get; set; }

        //Login
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login not specified")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "String length must be between 5 and 50 characters")]
        public string Login { get; set; }

        //Password
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password not specified")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "String length must be between 5 and 200 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Password for confirm
        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "ConfirmPassword not specified")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "String length must be between 5 and 200 characters")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        //User`s full name
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "FullName not specified")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "String length must be between 3 and 100 characters")]
        public string FullName { get; set; }

        //Birth date
        [Display(Name = "Birth at")]
        [Required(ErrorMessage = "BirthAt not specified")]
        public DateTime? BirthAt { get; set; }

        //Email
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress(ErrorMessage = "Email is incorrect")]
        public string Email { get; set; }

        //Phone number
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone not specified")]
        [Phone(ErrorMessage = "Phone is incorrect")]
        public string Phone { get; set; }

        //Created date
        public DateTime? CreatedAt { get; set; }

        //Updated date
        public DateTime? UpdatedAt { get; set; }
    }
}
