#region Using
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace SmartAdminMvc.Models
{
    public class AccountLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class AccountForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class AccountResetPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }

    

    /*
    public class regsiterViewModel
    {
        [Required]
        [Display(Name = "UserRoles")]
        public string UserRoles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }    
    }
    */
    /*
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Cuenta")]
        public string cuenta {get ;  set;}
 
       [Required]
        [Display (Name = "Nombre")]
        public string nombre  {get ; set;}

        [Required]
        [Display( Name = "apellido")]
        public string apellido {get; set;}

        [Required]
        [Display (Name = "email")]
        public string email {get; set;}


        [Required]
        [Display (Name = "Activos")]
        public string activo {get; set;}

        [Required]
        [Display (Name = "Usuario")]
        public string Usuario {get; set;}


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display (Name = "clave")]
        public string clave {get; set;}

    }

     */
 
    public class AccountRegistrationModel
    {

        public string Username { get; set; }
        

        public string Activo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email")]
        public string EmailConfirm { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }


       


    }
}