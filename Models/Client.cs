using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// Created by Sean

namespace NBDv2.Models
{
    public class Client
    {
        public Client()
        {
            Projects = new HashSet<Project>();
        }

        public int ID { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name Can't Be Left Blank")]
        [StringLength(50, ErrorMessage = "Name Can't Be Larger Than 50 Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 Phone { get; set; }

        [StringLength(50, ErrorMessage = "Address Can't Be Larger Than 50 Characters")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "Province Can't Be Larger Than 50 Characters")]
        public string Province { get; set; }

        [StringLength(15, ErrorMessage = "Postal Code is too large")]
        [DataType(DataType.PostalCode)]
        public string Postal { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string ConFirst { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string ConLast { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 ConPhone { get; set; }

        [Display(Name = "Contact Position")]
        [StringLength(30, ErrorMessage = "Position Must Be 30 Characters or Less")]
        public string ConPosition { get; set; }

        [Display(Name = "City")]
        public int CityID { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
