using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace OnlineFIR.WebApp.Models.ViewModel
{
    public class AddFIRView
    {
        [Key]
        public string fir_id { get; set; }
        //[Required(ErrorMessage = "Please select station ID")]
        [Display(Name = "Station ID")]
        public string station_id { get; set; }
        [Required(ErrorMessage = "Please enter name of the person filing the FIR")]
        [Display(Name = "Name Of the person filing the FIR")]
        public string fir_complaintnee_name { get; set; }
        [DataType(DataType.PhoneNumber)]
        [MinLength(10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Mobile Number Of the person filing the FIR")]
        public string fir_complaintnee_mob_no { get; set; }
        public string fir_date { get; set; }
        [Required(ErrorMessage = "Please enter subject of FIR.")]
        [Display(Name = "Subject of the FIR")]
        public string fir_subject { get; set; }
       // [Required(ErrorMessage = " ")]
        [Display(Name = "FIR Document")]
        public string fir_file_path { get; set; }
        public string fir_status { get; set; }
        [Required(ErrorMessage = "Please enter AADHAR Number Of the person filing the FIR")]
        [StringLength(12)]
        [Display(Name = "AADHAR Number Of the person filing the FIR")]
        public string aadhar_num { get; set; }
        [Required(ErrorMessage = "Please enter email of the person filing the FIR")]
        [Display(Name = "Email Of the person filing the FIR")]
        public string email { get; set; }
    }

    public class LoginView
    {
        [Key]
        [Required(ErrorMessage = "Please enter user ID")]
        [Display(Name = "User ID")]
        public string user_id { get; set; }
        [Required(ErrorMessage = "Please enter user password")]
        [Display(Name = "User Password")]
        public string user_password { get; set; }
        public string user_role { get; set; }
    }

    public class EditPoliceStation
    {
        [Key]
        [Display(Name = "Station ID")]
        public string station_id { get; set; }
        [Display(Name = "Station Incharge's ID")]
        public string user_id { get; set; }
        [Required(ErrorMessage = "Please enter station name")]
        [Display(Name = "Station Name")]
        public string station_name { get; set; }
        [Required(ErrorMessage = "Please enter station address")]
        [Display(Name = "Station address")]
        public string station_address { get; set; }
        [Required(ErrorMessage = "Please enter station incharge name")]
        [Display(Name = "Station Incharge Name")]
        public string station_incharge { get; set; }
        [Required(ErrorMessage = "Please enter station contact number")]
        [Display(Name = "Station Phone Number")]
        public string station_contact_no { get; set; }
    }


    public class AddPoliceStation
    {
        [Key]
        [Required(ErrorMessage = "Please enter station ID")]
        [Display(Name = "Station ID")]
        public string station_id { get; set; }
        [Required(ErrorMessage = "Please enter station Incharge's ID")]
        [Display(Name = "Station Incharge's ID")]
        public string user_id { get; set; }
        [Required(ErrorMessage = "Please enter station name")]
        [Display(Name = "Station Name")]
        public string station_name { get; set; }
        [Required(ErrorMessage = "Please enter station address")]
        [Display(Name = "Station address")]
        public string station_address { get; set; }
        [Required(ErrorMessage = "Please enter station incharge name")]
        [Display(Name = "Station Incharge Name")]
        public string station_incharge { get; set; }
        [Required(ErrorMessage = "Please enter station contact number")]
        [Display(Name = "Station Phone Number")]
        public string station_contact_no { get; set; }
    }

}