using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IV_Rovers.Model
{
    public class Player
    {
        public int PlayerID { get; set; }

        [Required(ErrorMessage = "You must add a firstname!")]
        [StringLength(50, ErrorMessage = "Maxlength for firstname is 50 characters")]
        public string FName { get; set; }

        [Required(ErrorMessage = "You must add a lastname!")]
        [StringLength(50, ErrorMessage = "Maxlength for lastname is 50 characters")]
        public string LName { get; set; }

        [Required(ErrorMessage = "You must add the players heigth!")]
        public byte Height { get; set; }

        [Required(ErrorMessage = "You must add the players weight!")]
        public byte Weight { get; set; }

        [Required(ErrorMessage = "You must add the players shirtnumber!")]
        public byte ShirtNr { get; set; }
    }
}