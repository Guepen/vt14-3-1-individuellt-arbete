using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IV_Rovers.Model
{
    public class Player
    {
        public int PlayerID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public byte ShirtNr { get; set; }
    }
}