using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAO_CSV_v06.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Cathegory { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string MobileNum { get; set; }
        public string Mail { get; set; }
    }
}