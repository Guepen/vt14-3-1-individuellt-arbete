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
        [MaxLength(3, ErrorMessage = "Maxlength for height is 3 numbers")]
        public int Height { get; set; }

        [Required(ErrorMessage = "You must add the players weight!")]
        [MaxLength(3, ErrorMessage = "Maxlength for weight is 3 numbers")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "You must add the players shirtnumber!")]
        [MaxLength(2, ErrorMessage = "Maxlength for shirtnumber is 2 numbers")]
        public byte ShirtNr { get; set; }
    }
}