using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsappAPI.Models
{
    public class Property
    {
        public int PropertyID { get; set; }
        public string Postcode { get; set; }
        public long MobileNumber { get; set; }
        public string AppointmentDate { get; set; }
        public int HouseNumber { get; set; }
        public int SizeOfHouse { get; set; }
        public string AppointmentTime { get; set; }
    }
}
