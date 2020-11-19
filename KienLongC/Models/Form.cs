using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KienLongC.Models
{
    public class Form
    {
        [Key]
        [Column("FormId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }



        [Display(Name = "Email Address")]
        [DisplayFormat(NullDisplayText = "Never connected")]
        [Column("Email")]
        [Required]

        public string EmailInput { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string ContactType { get; set; }
       
        public string StaffName { get; set; }

        /// <summary>
        /// updjate this
        /// </summary>
        /// 
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime RegisDate { get; set; }


        public Form()
        { 
        }
        

    }
    
  /*  public class Name
    {

        [DisplayName("Moron")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
  */
}
